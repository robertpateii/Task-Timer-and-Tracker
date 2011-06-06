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
				// Create the textBox and set it's text to the task's name.
				TextBox aTextBox = new TextBox();
				aTextBox.Text = aTask.Name;
				myTextBoxes.Add(aTextBox);

				// Create the radio button and set it to the checked status
				RadioButton aRadio = new RadioButton();
				aRadio.Checked = aTask.IsChecked;
				aRadio.Click += new EventHandler(aRadio_Click);
				myRadioButtons.Add(aRadio);

				// Create the time label and set it to the task's time
				Label aTimeLabel = new Label();
				aTimeLabel.Text = aTask.TimeString;
				aTimeLabel.Click += new EventHandler(aTimeLabel_Click);
				myTimeLabels.Add(aTimeLabel);
			}


			// Add the stuff to the form
			addTextBoxes();
			addradioButtons();
			addtimeLabels();
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
			MessageBox.Show("editing times not implemented yet.");
		}

		private void addradioButtons()
		{
			// Set Starting position
			int x = 200;
			int y = 15;

			// Add all the radio buttons
			foreach (RadioButton aButton in myRadioButtons)
			{
				aButton.Location = new Point(x, y);
				y += 25;
				this.Controls.Add(aButton);
			}
		}

		private void addtimeLabels()
		{
			// Starting Pos
			int x = 300;
			int y = 15;

			// Add all the labels
			foreach (Label aLabel in myTimeLabels)
			{
				aLabel.Location = new Point(x, y);
				y += 25;
				this.Controls.Add(aLabel);
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
				this.Controls.Add(aTextBox);
			}
		}

		private void createBlankTasks()
		{
			// Create some blank tasks anyway
			for (int i = 0; i < 4; i++)
			{

				Task aTask = new Task(i.ToString(), TimeSpan.Zero, false);
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
			foreach (Label aTimeLabel in myTimeLabels)
			{
				if (myTasks.IndexOf(aTask) == myTimeLabels.IndexOf(aTimeLabel))
				{
					aTimeLabel.Text = aTask.TimeString;		
				}
			}
		}

	}
}
  