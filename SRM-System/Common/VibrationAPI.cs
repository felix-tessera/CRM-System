using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM_System.Common
{
    public class VibrationAPI
    {
        public static void ToVibrate()
        {
            double secondsToVibrate = 0.3;
            TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);
#if ANDROID
            Vibration.Default.Vibrate(vibrationLength);
#endif
        }

        public static void VibrateStopButton_Clicked(object sender, EventArgs e) =>
            Vibration.Default.Cancel();
    }
}
