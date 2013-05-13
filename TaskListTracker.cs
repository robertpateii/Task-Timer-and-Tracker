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
		const string formTitle = "HaveDone Task Tracker"; // if you change this you also need to change it in the form designer.
        const string checkInString = "Check In";
        const string inProgressString = "In Progress";
        const string errorEditingTwoTimes = "You can only edit one time at a time.";
        const string titleBreakReady = "Take a break!";
        const string messageBreakReady = "50 minutes has passed since your last break.\r\nClick OK to start your break.";
        const string titleBreakRunning = "On Break";
        const string messageBreakRunning = "Task timer paused. Click OK when you are back and resume work.";
        const int timeLabelWidth = 35;
        const int radioWidth = 85;
        const int changeTimeBoxWidth = 25;
		List<TextBox> myTextBoxes = new List<TextBox> { };
		List<RadioButton> myRadioButtons = new List<RadioButton> { };
		List<Label> myTimeLabels = new List<Label> { };
		List<TextBox> myChangeTimeBoxes = new List<TextBox> { };
        internal Dictionary<OptionKeys, OptionValues> OptionsList = new Dictionary<OptionKeys,OptionValues>();
        internal enum OptionKeys
        {
            BreakTimerEnabled
        }
        internal enum OptionValues {
            True, False
        }


		public TaskListTracker()
		{
			InitializeComponent();
			this.Text = formTitle;
			loadFromFile();
			loadFormControls();
		}

        internal bool BreakTimerOff() 
        {
            bool success = false;
            breakTimer.Stop();
            if (breakTimer.Enabled == false)
            {
                OptionsList[OptionKeys.BreakTimerEnabled] = OptionValues.False;
                success = true;
            }
            return success;
        }

        internal bool BreakTimerOn()
        {
            bool success = false;
            breakTimer.Start();
            if (breakTimer.Enabled)
            {
                OptionsList[OptionKeys.BreakTimerEnabled] = OptionValues.True;
                success = true;
            }
            return success;
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

		// Sets all the other tasks IsChecked Property to false
		// Then sets the selected task's IsChecked property to true
		void aRadio_Click(object sender, EventArgs e)
		{
			RadioButton button = (RadioButton)sender;
			int buttonIndex = myRadioButtons.IndexOf(button);
			checkInTask(buttonIndex);		
		}

		// Overload for below method
		private void checkInTask(Task aTask)
		{
			int taskIndex = myTasks.IndexOf(aTask);
			checkInTask(taskIndex);
		}

		private void checkInTask(int taskIndex)
		{
			// Set every task's checked in status to false
			foreach (Task aTask in myTasks)
			{
				aTask.IsChecked = false;
			}

			// Set the newly checked one to true
			myTasks[taskIndex].IsChecked = true;

			// Set all the radio button's text to "Check In"
			foreach (RadioButton aRadioButton in myRadioButtons)
			{
				aRadioButton.Text = checkInString;
			}

			// Set the newly checked one to "In Progress"
			myRadioButtons[taskIndex].Text = inProgressString;

			// If the newly checked radio button isn't already checked, check it
			if (myRadioButtons[taskIndex].Checked == false)
			{
				myRadioButtons[taskIndex].Checked = true;
			}

			// Set the title of the form to the task
			if (myTextBoxes[taskIndex].Text == "")
			{
				this.Text = formTitle;
			}
			else
			{
				this.Text = myTextBoxes[taskIndex].Text;
			}
		}

		void aTimeLabel_Click(object sender, EventArgs e)
		{
			// if a change time text box is already visible, do nothing. 
			if (buttonSave.Visible == true)
			{
				MessageBox.Show(errorEditingTwoTimes);
			}

			else
			{

				// Hide the time label
				Label thisLabel = (Label)sender;
				thisLabel.Hide();
				// get the index of the sender and unhide the changeTimeBox of the same index. 
				int senderIndex = myTimeLabels.IndexOf(thisLabel);
				myChangeTimeBoxes[senderIndex].Clear();
				myChangeTimeBoxes[senderIndex].Show();
				myChangeTimeBoxes[senderIndex].Focus();
				// Also show the save & delete button. just have 1 save button not per task.
				buttonSave.Show();
				this.AcceptButton = buttonSave;
				buttonDelete.Show();
				buttonAddTask.Enabled = false;
				buttonCheckOut.Enabled = false;

				// Note that the user is still checked in while the change time box is open.
			}
			

		}

		private void createTaskControls(Task aTask)
		{
			// Create the textBox and set it's text to the task's name.
			TextBox aTextBox = new TextBox();
			aTextBox.Text = aTask.Name;
			myTextBoxes.Add(aTextBox);

			// Create the radio button and set it to the checked status
			RadioButton aRadio = new RadioButton();
			aRadio.Click += new EventHandler(aRadio_Click);
			myRadioButtons.Add(aRadio);
			aRadio.Width = radioWidth;
			aRadio.Text = checkInString;
			if (aTask.IsChecked)
			{
				checkInTask(aTask);
			}

			// Create the time label and set it to the task's time
			Label aTimeLabel = new Label();
			aTimeLabel.Text = aTask.TimeString;
			aTimeLabel.Click += new EventHandler(aTimeLabel_Click);
			aTimeLabel.Width = timeLabelWidth;
			myTimeLabels.Add(aTimeLabel);

			// Create the change time text box and set its properties
			TextBox changeTimeBox = new TextBox();
			changeTimeBox.Width = changeTimeBoxWidth;
			myChangeTimeBoxes.Add(changeTimeBox);
		}

		private void addTextBoxes()
		{
			// Set starting position for the text boxes
            // Find top and left of the group box and make these relative to it.
			int x = 7;
			int y = 20;

			// Add all the text boxes
			foreach (TextBox aTextBox in myTextBoxes)
			{
				aTextBox.Location = new Point(x, y);
				// Increase the y of the next text box
				y += 27;
				groupBoxTasks.Controls.Add(aTextBox);
			}
		}

		private void addRadioButtons()
		{
			// Set Starting position
            // find the position of the text boxes and set this relative to it.
			int x = 117;
			int y = 18;

			// Add all the radio buttons
			foreach (RadioButton aButton in myRadioButtons)
			{
				aButton.Location = new Point(x, y);
				y += 27;
				groupBoxTasks.Controls.Add(aButton);
			}
		}

		private void addTimeLabels()
		{
			// Starting Pos
            // Find position of radio buttons and set this relative to it
			int x = 208;
			int y = 23;

			// Add all the labels
			foreach (Label aLabel in myTimeLabels)
			{
				aLabel.Location = new Point(x, y);
				y += 27;
				groupBoxTasks.Controls.Add(aLabel);
			}
		}

		private void addChangeTimeBoxes()
		{
			// Starting Pos same as time labels
			int x = 208;
			int y = 23;

			// Add all the text boxes but hide them
			foreach (TextBox aTextBox in myChangeTimeBoxes)
			{
				aTextBox.Location = new Point(x, y);
				y += 27;
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

            if (File.Exists("TaskListTrackerOptions.dat"))
            {
                try
                {
                    using (Stream inputstream = File.OpenRead("TaskListTrackerOptions.dat"))
                    {
                        BinaryFormatter myFormatter = new BinaryFormatter();
                        OptionsList = (Dictionary<OptionKeys, OptionValues>)myFormatter.Deserialize(inputstream);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                OptionsList.Add(OptionKeys.BreakTimerEnabled, OptionValues.True);
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
			using (Stream output = File.Create("TaskListTrackerOptions.dat"))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(output, OptionsList);
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

			// Updates the title of the form in case you've changed the text of a task without checking in again
			this.Text = myTextBoxes[taskIndex].Text;
		}

		private void buttonAddTask_Click(object sender, EventArgs e)
		{
			SaveTaskList(); // I'm only really saving here so that the text in the task fields is saved to the task object.

			// Add a blank task to the array
			Task newTask = new Task();
			newTask.Name = "New Task";
			myTasks.Add(newTask);
			
			// wipe out all the buttons and text and task stuff on the form
			groupBoxTasks.Controls.Clear();
			
			// Create the buttons and stuff for the new task (the other stuff still exists off-form)
			createTaskControls(newTask);
			
			// Add the whole lot of controls back to the form
			redrawForm();
			
			// Set the text box focus to the newly created task
			int newTaskIndex = myTasks.IndexOf(newTask);
			myTextBoxes[newTaskIndex].Focus();

			// Set the new task so it's checked in
			checkOutAllTasks();
			checkInTask(newTaskIndex);
		}

		private void buttonCheckOut_Click(object sender, EventArgs e)
		{
			checkOutAllTasks();
		}

		private void checkOutAllTasks()
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

			this.Text = formTitle;
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
						if (aTimeBox.Text == "")
						{
							aTimeBox.Text = "0";
						}
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

		private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Form aboutForm = new TaskTracker.About(this);
			aboutForm.Show();
		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}

		private void breakTimer_Tick(object sender, EventArgs e)
		{
			// Timer is set to tick every minute (60,000 milliseconds).
			// Increment bar for each minute.
			if (breakTimerProgressBar.Value >= breakTimerProgressBar.Maximum)
			{
				breakTimerProgressBar.Value = breakTimerProgressBar.Minimum;
				breakTimer.Stop();
				this.Activate();
				MessageBox.Show(messageBreakReady, titleBreakReady); // Click OK to start your break
				timer1.Stop(); // Stop the task timer *after* the user accepts the break.
				MessageBox.Show(messageBreakRunning, titleBreakRunning); // Click OK to end your break
				breakTimer.Start();
				timer1.Start();
			}
			else
			{
				breakTimerProgressBar.Value++;
			}
		}

		private void breakTimerResetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			breakTimerProgressBar.Value = 0;
		}
    }
}
