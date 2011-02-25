using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TaskTracker
{
	public partial class Form1 : Form
	{
		bool checkedIn;
		TaskTimer myTaskTimer;
		const string saveFileName = "TaskTimeData.txt";
		const string myWebsiteLink = "http://robertpateii.com";
		public Form1()
		{
			InitializeComponent();
			checkedIn = false;
			myTaskTimer = new TaskTimer(TimeSpan.Zero);
			if (File.Exists(saveFileName) == true)
			{
				changeTime(File.ReadAllText(saveFileName));
			}
			// 10 second interval. This is set in "Form1.Designer.cs" to a different value, but the value here takes precedence.
			timer1.Interval = 10000;
			updateMyTaskTime();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			if (checkedIn == false)
			{
				// Log in / Check in
				myTaskTimer.Start(); // Starts the core timer
				timer1.Start(); // Starts the form's timer used to update the GUI
				updateMyTaskTime();
				saveMyTaskTime();
				checkedIn = true;
				loginButton.Text = "Check Out";
				this.Text = "Checked In - Task Timer"; 
			}

			else // Log out / check out
			{
				myTaskTimer.Pause();
				timer1.Stop();
				updateMyTaskTime();
				saveMyTaskTime();
				checkedIn = false;
				loginButton.Text = "Check In";
				this.Text = "Checked Out - Task Timer";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			updateMyTaskTime();
		}

		private void updateMyTaskTime()
		{
			TimeSpan myTaskTime;
			myTaskTime = myTaskTimer.TaskTime;
			string taskTimeString = myTaskTime.Days + "d " + myTaskTime.Hours + "h " + myTaskTime.Minutes + "m";
			taskTimeLabel.Text = taskTimeString;
		}

		private void saveMyTaskTime()
		{
			File.WriteAllText(saveFileName, myTaskTimer.TaskTime.ToString());
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			saveMyTaskTime();
		}

		private void infoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("This program saves your data everytime you Check In, Check Out, or Close.\r\n" + myWebsiteLink);
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			myTaskTimer.TaskTime = TimeSpan.Zero;
			updateMyTaskTime();
		}

		private void taskTimeLabel_Click(object sender, EventArgs e)
		{
			// Hide the normal timer display label
			taskTimeLabel.Visible = false;

			// Show the editable text box and save button
			textBoxChangeTime.Visible = true;
			buttonSave.Visible = true;

			// Set the time displayed in the text box to the current time counted
			textBoxChangeTime.Text = myTaskTimer.TaskTime.ToString();
			


		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			// Take the text with each change and attempt to change the time with it.
			string savedTaskTime = textBoxChangeTime.Text;
			changeTime(savedTaskTime);
			
			// Hide the save button and editable text box. Return the normal timer label.
			buttonSave.Visible = false;
			textBoxChangeTime.Visible = false;
			taskTimeLabel.Visible = true;

			// Update the timer label w/ latest time.
			updateMyTaskTime();
		}

		private void changeTime(object source)
		{
			string savedTaskTime = (string)source;
			// Ensure the savedTaskTime string is in an acceptable format for conversion, not just that it exists.
			try
			{
				if (!string.IsNullOrEmpty(savedTaskTime))
				{
					// Converts from the saved string to a TimeSpan object.
					TimeSpan savedTaskTimeSpan = TimeSpan.Parse(savedTaskTime);
					myTaskTimer.TaskTime = savedTaskTimeSpan;
				}
				else
				{
					myTaskTimer.TaskTime = TimeSpan.Zero;
				}
			}

			catch (Exception)
			{
				MessageBox.Show("The time you tried to save isn't in the right format, and so was not saved.");
			}

			finally
			{
				//
			}
		}

		private void buttonResetBoth_Click(object sender, EventArgs e)
		{
			textBoxTask.Text = "";
			myTaskTimer.TaskTime = TimeSpan.Zero;
			updateMyTaskTime();
		}
	}
}
