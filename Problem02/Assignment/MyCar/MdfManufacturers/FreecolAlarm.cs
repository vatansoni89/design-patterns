using Freecol;
using System;
using System.Collections.Generic;
using System.Text;
using WonderTools.VendorContract;

namespace MdfManufacturers
{
    /// <summary>
    ///
    /// </summary>
    public class FreecolAlarm : IAlarm
    {
        public LowFrequencyAlarm LowFrequencyAlarm { get; set; }

        public FreecolAlarm()
        {
            LowFrequencyAlarm = new LowFrequencyAlarm();
        }

        public void RaiseAlarm()
        {
            LowFrequencyAlarm.Beep();
        }
    }
}