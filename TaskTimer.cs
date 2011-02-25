using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TaskTracker
{
	public class TaskTimer
	{
		// Properties
		Timer myTimer;
		TimeSpan taskTime;
		public TimeSpan TaskTime 
		{ 
			get { return taskTime; } 

			set {
				// should I be running a try/catch here? or on the form?
				taskTime = value;
				} 
		}

		// Constructor
		// the play time will only change from the outside if you create a new instance of play timer.
		public TaskTimer(TimeSpan taskTime)
		{
			this.taskTime = taskTime;
			myTimer = new Timer(1000);  // it's in milliseconds, so 1000 = one second


			// This hooks up the progress of the timer to the OnTimedEvent method.
			myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			
		}

		// Methods
		public void Start()
		{
			// Called by a button on the form to resume the counter.
			// If we can keep taskTime updated, the form can create its own timer and just check TaskTime at whatever interval it wants.
			// So this method needs to use a timer. And it needs add itself to taskTime.
			// ...Well i don't think I can create the timer in this method. From the msdn example, it uses its own event method.
			// And that's fine, i'm able to use OnTimedEvent below to keep taskTime updated on each second the timer runs.

			myTimer.Start();			
		}

		void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			TimeSpan seconds = new TimeSpan(0, 0, 0, 1);
			taskTime = taskTime + seconds;
		}

		public void Pause()
		{
			// Pauses the play time counter
			// Form may call this something different. i.e. Stop. But the essence is it's just a pause while the user goes to bed or what have you.
			// Will need to save to disk on pause (and pause on closing program.) May want to save elsewhere periodically too in case of crash.
			myTimer.Stop();
		}			
		
	}
}
