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
		TaskTimer myTaskTimer;
		const string saveFileName = "TaskTimeData.txt";
		const string myWebsiteLink = "http://robertpateii.com";
		public Form1()
		{
			InitializeComponent();
			if (File.Exists(saveFileName) == true)
			{
				string savedTaskTime = File.ReadAllText(saveFileName);
				if (!string.IsNullOrEmpty(savedTaskTime))
				{
					// Converts from the saved string to a TimeSpan object.
					TimeSpan savedTaskTimeSpan = TimeSpan.Parse(savedTaskTime);
					myTaskTimer = new TaskTimer(savedTaskTimeSpan);
				}
				else
				{
					myTaskTimer = new TaskTimer(TimeSpan.Zero);
				}
			}
			else
			{
				myTaskTimer = new TaskTimer(TimeSpan.Zero);
			}
			// 10 second interval. This is set in "Form1.Designer.cs" to a different value, but the value here takes precedence.
			timer1.Interval = 10000;
			logoutButton.Enabled = false;
			updateMyTaskTime();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			myTaskTimer.Start(); // Starts the core timer
			timer1.Start(); // Starts the form's timer used to update the GUI
			loginButton.Enabled = false;
			logoutButton.Enabled = true;
			updateMyTaskTime();
			saveMyTaskTime();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			updateMyTaskTime();
		}

		private void logoutButton_Click(object sender, EventArgs e)
		{
			myTaskTimer.Pause();
			timer1.Stop();
			loginButton.Enabled = true;
			logoutButton.Enabled = false;
			updateMyTaskTime();
			saveMyTaskTime();
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

	}
}
