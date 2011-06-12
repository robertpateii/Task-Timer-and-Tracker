using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TaskTracker
{
	public partial class TaskListTracker : Form
	{
		List<Task> myTasks = new List<Task> { };
		const string saveTimeFile = "TaskListTracker.dat";
		List<TextBox> myTextBoxes = new List<TextBox> { };
		List<RadioButton> myRadioButtons = new List<RadioButton> { };
		List<Label> myTimeLabels = new List<Label> { };
		List<TextBox> myChangeTimeBoxes = new List<TextBox> { };

		public TaskListTracker()
		{
			InitializeComponent();
			loadFromFile();
			loadFormControls();
		}

		private void loadFormControls()
		{
			// Create the stuff on the form w/ the data in the tasks
			foreach (Task aTask in myTasks)
			{
				createTaskControls(aTask);
			}


			// Add the stuff to the form
			redrawForm();
		}

		private void createTaskControls(Task aTask)
		{
			// Create the textBox and set it's text to the task's name.
			TextBox aTextBox = new TextBox();
			aTextBox.Text = aTask.Name;
			myTextBoxes.Add(aTextBox);

			// Create the radio button and set it to the checked status
			RadioButton aRadio = new RadioButton();
			aRadio.Checked = aTask.IsChecked;
			aRadio.Click += new EventHandler(aRadio_Click);
			myRadioButtons.Add(aRadio);
			aRadio.Width = 25;

			// Create the time label and set it to the task's time
			Label aTimeLabel = new Label();
			aTimeLabel.Text = aTask.TimeString;
			aTimeLabel.Click += new EventHandler(aTimeLabel_Click);
			myTimeLabels.Add(aTimeLabel);

			// Create the change time text box and set its properties
			TextBox changeTimeBox = new TextBox();
			changeTimeBox.Width = 25;
			myChangeTimeBoxes.Add(changeTimeBox);
		}

		// Sets all the other tasks IsChecked Property to false
		// Then sets the selected task's IsChecked property to true
		void aRadio_Click(object sender, EventArgs e)
		{
			RadioButton button = (RadioButton)sender;
			int buttonIndex = myRadioButtons.IndexOf(button);
			foreach (Task aTask in myTasks)
			{
				aTask.IsChecked = false;
			}
			myTasks[buttonIndex].IsChecked = true;
			
		}

		void aTimeLabel_Click(object sender, EventArgs e)
		{
			// if a change time text box is already visible, do nothing. 
			if (buttonSave.Visible == true)
			{
				MessageBox.Show("You can only edit one time at a time.");
			}

			else
			{

				// Hide the time label
				Label thisLabel = (Label)sender;
				thisLabel.Hide();
				// get the index of the sender and unhide the changeTimeBox of the same index. 
				int senderIndex = myTimeLabels.IndexOf(thisLabel);
				myChangeTimeBoxes[senderIndex].Show();
				myChangeTimeBoxes[senderIndex].Focus();
				// Also show the save & delete button. just have 1 save button not per task.
				buttonSave.Show();
				buttonDelete.Show();
				buttonAddTask.Enabled = false;
				buttonCheckOut.Enabled = false;

				// Note that the user is still checked in while the change time box is open.
			}
			

		}

		private void addRadioButtons()
		{
			// Set Starting position
			int x = 125;
			int y = 15;

			// Add all the radio buttons
			foreach (RadioButton aButton in myRadioButtons)
			{
				aButton.Location = new Point(x, y);
				y += 25;
				groupBoxTasks.Controls.Add(aButton);
			}
		}

		private void addTimeLabels()
		{
			// Starting Pos
			int x = 190;
			int y = 15;

			// Add all the labels
			foreach (Label aLabel in myTimeLabels)
			{
				aLabel.Location = new Point(x, y);
				y += 25;
				groupBoxTasks.Controls.Add(aLabel);
			}
		}

		private void addChangeTimeBoxes()
		{
			// Starting Pos same as time labels
			int x = 190;
			int y = 15;

			// Add all the text boxes but hide them
			foreach (TextBox aTextBox in myChangeTimeBoxes)
			{
				aTextBox.Location = new Point(x, y);
				y += 25;
				groupBoxTasks.Controls.Add(aTextBox);
				aTextBox.Hide();
			}
		}

		private void loadFromFile()
		{
			if (File.Exists(saveTimeFile) == true)
			{
				try
				{
					using (Stream inputstream = File.OpenRead(saveTimeFile))
					{
						List<Task> savedTaskList;
						BinaryFormatter myFormatter = new BinaryFormatter();
						savedTaskList = (List<Task>)myFormatter.Deserialize(inputstream);
						myTasks = savedTaskList;
					}
				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					createBlankTasks();
				}
			}
			else
			{
				createBlankTasks();
			}
		}

		private void addTextBoxes()
		{
			// Set starting position for the text boxes
			int x = 15;
			int y = 15;

			// Add all the text boxes
			foreach (TextBox aTextBox in myTextBoxes)
			{
				aTextBox.Location = new Point(x, y);
				// Increase the y of the next text box
				y += 25;
				groupBoxTasks.Controls.Add(aTextBox);
			}
		}

		private void createBlankTasks()
		{
			// Create some blank tasks anyway
			for (int i = 0; i < 2; i++)
			{
				Task aTask = new Task("", TimeSpan.Zero, false);
				myTasks.Add(aTask);
			}
		}

		private void SaveTaskList()
		{
			// Saves the names of each task to the task object
			for (int i = 0; i < myTextBoxes.Count; i++)
			{
				myTasks[i].Name = myTextBoxes[i].Text;
				
			}

			// See aRadio_Click for when the IsChecked property gets saved to the task object

			// See timer1_Tick - it adds the new time directly to the task

			// Save the task list to a file
			using (Stream output = File.Create(saveTimeFile))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(output, myTasks);
			}
		}

		private void TaskListTracker_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveTaskList();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			// Take the tick interval and add it to the time of the checked task
			foreach (Task aTask in myTasks)
			{
				if (aTask.IsChecked)
				{
					// Create a time span that equals the interval
					TimeSpan tickTime = new TimeSpan((long)timer1.Interval * 10000);

					// Add that time span to the task
					aTask.Time = aTask.Time.Add(tickTime);

					updateTimes(aTask);
				}
			}
		}

		// Update the time of the checked task or all the tasks if you have to. 
		// It will run whenever the timer tick updates a task's time.
		private void updateTimes(Task aTask)
		{
			int taskIndex = myTasks.IndexOf(aTask);
			myTimeLabels[taskIndex].Text = aTask.TimeString;
		}

		private void buttonAddTask_Click(object sender, EventArgs e)
		{
			SaveTaskList(); // I'm only really saving here so that the text in the task fields is saved to the task object.
			// Add a blank task to the array
			Task newTask = new Task();
			myTasks.Add(newTask);
			// wipe out all the buttons and text and task stuff on the form
			groupBoxTasks.Controls.Clear();
			// Create the buttons and stuff for the new task (the other stuff still exists off-form)
			createTaskControls(newTask);
			// Add the whole lot of controls back to the form
			redrawForm();
		}

		private void buttonCheckOut_Click(object sender, EventArgs e)
		{
			foreach (Task aTask in myTasks)
			{
				if (aTask.IsChecked)
				{
					aTask.IsChecked = false;
				}
			}

			foreach (RadioButton aRadioButton in myRadioButtons)
			{
				aRadioButton.Checked = false;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			foreach (TextBox aTimeBox in myChangeTimeBoxes)
			{

				if (aTimeBox.Visible == true)
				{
					int changeTimeValueInMinutes = 0;
					// Convert the change time value into a time span.
					try
					{
						changeTimeValueInMinutes = int.Parse(aTimeBox.Text);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}

					TimeSpan changeTimeTimeSpan = new TimeSpan(0, changeTimeValueInMinutes, 0);

					// Take the index of the change time box and use it to get the index of the corresponding items
					// I feel like i've written this too many times i need to make a function.
					int taskIndex = myChangeTimeBoxes.IndexOf(aTimeBox);

					// add the minutes in the time box to the task itself. then run the update to the form's time label.
					myTasks[taskIndex].Time = myTasks[taskIndex].Time.Add(changeTimeTimeSpan);
					updateTimes(myTasks[taskIndex]);
					
					// Put the time label and change time box back to normal.
					aTimeBox.Hide();
					myTimeLabels[taskIndex].Show();


				}
			}
			// put all the buttons back to normal
			buttonAddTask.Enabled = true;
			buttonCheckOut.Enabled = true;
			buttonSave.Hide();
			buttonDelete.Hide();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			// setting this to 99 since it's a value unlikely to already match a task
			int taskIndex = 99;
			
			// Find what index the task is at
			foreach (TextBox aTimeBox in myChangeTimeBoxes)
			{
				if (aTimeBox.Visible == true)
				{
					taskIndex = myChangeTimeBoxes.IndexOf(aTimeBox);
				}
			}

			// Delete the task and corresponding buttons
			myChangeTimeBoxes.RemoveAt(taskIndex);
			myRadioButtons.RemoveAt(taskIndex);
			myTasks.RemoveAt(taskIndex);
			myTextBoxes.RemoveAt(taskIndex);
			myTimeLabels.RemoveAt(taskIndex);

			// Redraw the form
			redrawForm();


			// Put buttons back to normal.
			buttonAddTask.Enabled = true;
			buttonCheckOut.Enabled = true;
			buttonSave.Hide();
			buttonDelete.Hide();
		}

		private void redrawForm()
		{
			groupBoxTasks.Controls.Clear();
			addTextBoxes();
			addRadioButtons();
			addTimeLabels();
			addChangeTimeBoxes();
		}

	}
}
  