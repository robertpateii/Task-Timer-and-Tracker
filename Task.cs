using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskTracker
{
	[Serializable]
	public class Task
	{
		private string name;
		public string Name { get { return name; } set { name = value; } }
		
		private TimeSpan time;
		public TimeSpan Time 
		{ 
			get 
			{
				return time;
			} 
			set 
			{
				time = value; 
			} 
		}

		private bool isChecked;
		public bool IsChecked { get { return isChecked; } set { isChecked = value; } }

		public string TimeString
		{
			get
			{

				string timeString = time.Hours + ":" + time.Minutes;
				return timeString;

			}
		}

		public Task(string name, TimeSpan time, bool selected)
		{
			this.name = name;
			this.time = time;
			this.isChecked = selected;
		}

		public Task()
		{
			this.name = "";
			this.time = TimeSpan.Zero;
			this.isChecked = false;
		}
	}
}
