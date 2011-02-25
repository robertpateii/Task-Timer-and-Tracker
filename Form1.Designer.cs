namespace TaskTracker
{
	partial class Form1
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
			this.loginButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.logoutButton = new System.Windows.Forms.Button();
			this.taskTimeLabel = new System.Windows.Forms.Label();
			this.infoLinkLabel = new System.Windows.Forms.LinkLabel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.taskLabel = new System.Windows.Forms.Label();
			this.buttonClear = new System.Windows.Forms.Button();
			this.labelChangeTime = new System.Windows.Forms.Label();
			this.textBoxChangeTime = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(43, 72);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(75, 23);
			this.loginButton.TabIndex = 0;
			this.loginButton.Text = "Check In";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// logoutButton
			// 
			this.logoutButton.Location = new System.Drawing.Point(160, 72);
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(75, 23);
			this.logoutButton.TabIndex = 1;
			this.logoutButton.Text = "Check Out";
			this.logoutButton.UseVisualStyleBackColor = true;
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			// 
			// taskTimeLabel
			// 
			this.taskTimeLabel.AutoSize = true;
			this.taskTimeLabel.BackColor = System.Drawing.SystemColors.Info;
			this.taskTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.taskTimeLabel.ForeColor = System.Drawing.SystemColors.InfoText;
			this.taskTimeLabel.Location = new System.Drawing.Point(56, 25);
			this.taskTimeLabel.Name = "taskTimeLabel";
			this.taskTimeLabel.Size = new System.Drawing.Size(160, 39);
			this.taskTimeLabel.TabIndex = 2;
			this.taskTimeLabel.Text = "0d 0h 0m";
			this.taskTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.taskTimeLabel.Click += new System.EventHandler(this.taskTimeLabel_Click);
			// 
			// infoLinkLabel
			// 
			this.infoLinkLabel.AutoSize = true;
			this.infoLinkLabel.Location = new System.Drawing.Point(246, 9);
			this.infoLinkLabel.Name = "infoLinkLabel";
			this.infoLinkLabel.Size = new System.Drawing.Size(24, 13);
			this.infoLinkLabel.TabIndex = 3;
			this.infoLinkLabel.TabStop = true;
			this.infoLinkLabel.Text = "info";
			this.infoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.infoLinkLabel_LinkClicked);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(43, 125);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(192, 20);
			this.textBox1.TabIndex = 4;
			// 
			// taskLabel
			// 
			this.taskLabel.AutoSize = true;
			this.taskLabel.Location = new System.Drawing.Point(43, 106);
			this.taskLabel.Name = "taskLabel";
			this.taskLabel.Size = new System.Drawing.Size(77, 13);
			this.taskLabel.TabIndex = 5;
			this.taskLabel.Text = "Task reminder:";
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(98, 159);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(75, 23);
			this.buttonClear.TabIndex = 6;
			this.buttonClear.Text = "Reset Time";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// labelChangeTime
			// 
			this.labelChangeTime.AutoSize = true;
			this.labelChangeTime.Location = new System.Drawing.Point(60, 9);
			this.labelChangeTime.Name = "labelChangeTime";
			this.labelChangeTime.Size = new System.Drawing.Size(106, 13);
			this.labelChangeTime.TabIndex = 7;
			this.labelChangeTime.Text = "Click to change time:";
			// 
			// textBoxChangeTime
			// 
			this.textBoxChangeTime.Location = new System.Drawing.Point(59, 28);
			this.textBoxChangeTime.Multiline = true;
			this.textBoxChangeTime.Name = "textBoxChangeTime";
			this.textBoxChangeTime.Size = new System.Drawing.Size(153, 32);
			this.textBoxChangeTime.TabIndex = 8;
			this.textBoxChangeTime.Visible = false;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(223, 36);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(50, 24);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Visible = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 194);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxChangeTime);
			this.Controls.Add(this.labelChangeTime);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.taskLabel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.infoLinkLabel);
			this.Controls.Add(this.taskTimeLabel);
			this.Controls.Add(this.logoutButton);
			this.Controls.Add(this.loginButton);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Time Counter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button loginButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button logoutButton;
		private System.Windows.Forms.Label taskTimeLabel;
		private System.Windows.Forms.LinkLabel infoLinkLabel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label taskLabel;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Label labelChangeTime;
		private System.Windows.Forms.TextBox textBoxChangeTime;
		private System.Windows.Forms.Button buttonSave;
	}
}

