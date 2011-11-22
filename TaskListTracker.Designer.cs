namespace TaskTracker
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskListTracker));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.buttonAddTask = new System.Windows.Forms.Button();
			this.groupBoxTasks = new System.Windows.Forms.GroupBox();
			this.buttonCheckOut = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
			this.breakTimer = new System.Windows.Forms.Timer(this.components);
			this.breakTimerProgressBar = new System.Windows.Forms.ProgressBar();
			this.breakTimerLabel = new System.Windows.Forms.Label();
			this.breakTimerResetLabel = new System.Windows.Forms.LinkLabel();
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
			this.buttonAddTask.Location = new System.Drawing.Point(274, 27);
			this.buttonAddTask.Name = "buttonAddTask";
			this.buttonAddTask.Size = new System.Drawing.Size(112, 38);
			this.buttonAddTask.TabIndex = 0;
			this.buttonAddTask.Text = "Add New Task";
			this.buttonAddTask.UseVisualStyleBackColor = true;
			this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
			// 
			// groupBoxTasks
			// 
			this.groupBoxTasks.Location = new System.Drawing.Point(13, 12);
			this.groupBoxTasks.Name = "groupBoxTasks";
			this.groupBoxTasks.Size = new System.Drawing.Size(255, 311);
			this.groupBoxTasks.TabIndex = 1;
			this.groupBoxTasks.TabStop = false;
			this.groupBoxTasks.Text = "Tasks";
			// 
			// buttonCheckOut
			// 
			this.buttonCheckOut.Location = new System.Drawing.Point(274, 71);
			this.buttonCheckOut.Name = "buttonCheckOut";
			this.buttonCheckOut.Size = new System.Drawing.Size(112, 38);
			this.buttonCheckOut.TabIndex = 2;
			this.buttonCheckOut.Text = "Check Out";
			this.buttonCheckOut.UseVisualStyleBackColor = true;
			this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(274, 115);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(112, 38);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Visible = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(274, 194);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(112, 38);
			this.buttonDelete.TabIndex = 5;
			this.buttonDelete.Text = "Delete Task";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Visible = false;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// linkLabelHelp
			// 
			this.linkLabelHelp.AutoSize = true;
			this.linkLabelHelp.Location = new System.Drawing.Point(295, 330);
			this.linkLabelHelp.Name = "linkLabelHelp";
			this.linkLabelHelp.Size = new System.Drawing.Size(81, 13);
			this.linkLabelHelp.TabIndex = 7;
			this.linkLabelHelp.TabStop = true;
			this.linkLabelHelp.Text = "Help and About";
			this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
			// 
			// breakTimer
			// 
			this.breakTimer.Enabled = true;
			this.breakTimer.Interval = 60000;
			this.breakTimer.Tick += new System.EventHandler(this.breakTimer_Tick);
			// 
			// breakTimerProgressBar
			// 
			this.breakTimerProgressBar.Location = new System.Drawing.Point(286, 300);
			this.breakTimerProgressBar.Maximum = 60;
			this.breakTimerProgressBar.Name = "breakTimerProgressBar";
			this.breakTimerProgressBar.Size = new System.Drawing.Size(100, 23);
			this.breakTimerProgressBar.TabIndex = 8;
			this.breakTimerProgressBar.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// breakTimerLabel
			// 
			this.breakTimerLabel.AutoSize = true;
			this.breakTimerLabel.Location = new System.Drawing.Point(286, 281);
			this.breakTimerLabel.Name = "breakTimerLabel";
			this.breakTimerLabel.Size = new System.Drawing.Size(70, 13);
			this.breakTimerLabel.TabIndex = 9;
			this.breakTimerLabel.Text = "Break Timer -";
			// 
			// breakTimerResetLabel
			// 
			this.breakTimerResetLabel.AutoSize = true;
			this.breakTimerResetLabel.Location = new System.Drawing.Point(354, 281);
			this.breakTimerResetLabel.Name = "breakTimerResetLabel";
			this.breakTimerResetLabel.Size = new System.Drawing.Size(35, 13);
			this.breakTimerResetLabel.TabIndex = 10;
			this.breakTimerResetLabel.TabStop = true;
			this.breakTimerResetLabel.Text = "Reset";
			this.breakTimerResetLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.breakTimerResetLabel_LinkClicked);
			// 
			// TaskListTracker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 350);
			this.Controls.Add(this.breakTimerResetLabel);
			this.Controls.Add(this.breakTimerLabel);
			this.Controls.Add(this.breakTimerProgressBar);
			this.Controls.Add(this.linkLabelHelp);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCheckOut);
			this.Controls.Add(this.buttonAddTask);
			this.Controls.Add(this.groupBoxTasks);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "TaskListTracker";
			this.Text = "HaveDone Task Tracker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskListTracker_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonAddTask;
		private System.Windows.Forms.GroupBox groupBoxTasks;
		private System.Windows.Forms.Button buttonCheckOut;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.LinkLabel linkLabelHelp;
		private System.Windows.Forms.Timer breakTimer;
		private System.Windows.Forms.ProgressBar breakTimerProgressBar;
		private System.Windows.Forms.Label breakTimerLabel;
		private System.Windows.Forms.LinkLabel breakTimerResetLabel;

	}
}