﻿namespace TaskTracker
{
	partial class TaskListTracker
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.buttonAddTask = new System.Windows.Forms.Button();
			this.groupBoxTasks = new System.Windows.Forms.GroupBox();
			this.buttonCheckOut = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// buttonAddTask
			// 
			this.buttonAddTask.Location = new System.Drawing.Point(306, 316);
			this.buttonAddTask.Name = "buttonAddTask";
			this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
			this.buttonAddTask.TabIndex = 0;
			this.buttonAddTask.Text = "MOAR";
			this.buttonAddTask.UseVisualStyleBackColor = true;
			this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
			// 
			// groupBoxTasks
			// 
			this.groupBoxTasks.Location = new System.Drawing.Point(13, 12);
			this.groupBoxTasks.Name = "groupBoxTasks";
			this.groupBoxTasks.Size = new System.Drawing.Size(368, 298);
			this.groupBoxTasks.TabIndex = 1;
			this.groupBoxTasks.TabStop = false;
			this.groupBoxTasks.Text = "Tasks";
			// 
			// buttonCheckOut
			// 
			this.buttonCheckOut.Location = new System.Drawing.Point(157, 316);
			this.buttonCheckOut.Name = "buttonCheckOut";
			this.buttonCheckOut.Size = new System.Drawing.Size(75, 23);
			this.buttonCheckOut.TabIndex = 2;
			this.buttonCheckOut.Text = "Check Out";
			this.buttonCheckOut.UseVisualStyleBackColor = true;
			this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
			// 
			// TaskListTracker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 343);
			this.Controls.Add(this.buttonCheckOut);
			this.Controls.Add(this.buttonAddTask);
			this.Controls.Add(this.groupBoxTasks);
			this.Name = "TaskListTracker";
			this.Text = "TaskListTracker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskListTracker_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonAddTask;
		private System.Windows.Forms.GroupBox groupBoxTasks;
		private System.Windows.Forms.Button buttonCheckOut;

	}
}