using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // ConditionBase

namespace BBSamples.PQSG // Programmers Quick Start Guide
{
	[Condition("Samples/ProgQuickStartGuide/IsNight")]
	[Help("Checks whether it is night. It searches for the first light labeled with the 'MainLight' tag, and looks for its DayNightCycle script, returning the informed state. If no light is found, false is returned.")]
	public class DoneIsNightCondition : ConditionBase
	{
		public override bool Check()
		{
			if (lightExists())
				return light.isNight;
			else
				return false;
		}

        public override TaskStatus MonitorCompleteWhenTrue()
		{
			if (Check())
				return TaskStatus.COMPLETED;
			else
			{
				if (light != null)
					light.OnChanged += OnSunset;
				return TaskStatus.SUSPENDED;
			}
		}

        public override TaskStatus MonitorFailWhenFalse()
		{
			if (!Check())
				return TaskStatus.FAILED;
			else
			{
				light.OnChanged += OnSunrise;
				return TaskStatus.SUSPENDED;
			}
		}

        public void OnSunset(object sender, System.EventArgs night)
		{
			light.OnChanged -= OnSunset;
			EndMonitorWithSuccess();
		}

        public void OnSunrise(object sender, System.EventArgs e)
		{
			light.OnChanged -= OnSunrise;
			EndMonitorWithFailure();
		}

        public override void OnAbort()
		{
			if (lightExists())
			{
				light.OnChanged -= OnSunrise;
				light.OnChanged -= OnSunset;
			}
			base.OnAbort();
		}

		private bool lightExists()
		{
			if (light != null)
				return true;
			GameObject lightGO = GameObject.FindGameObjectWithTag("MainLight");

			if (lightGO == null)
				return false;
			light   = lightGO.GetComponent<DoneDayNightCycle>();
			return light != null;
		}
		private DoneDayNightCycle light;
	}
}