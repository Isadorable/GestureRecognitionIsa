using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestureForKinect.GestureManager.Gesture_Djestit
{
    public class SkeletonEventArgs : EventArgs
    {
        public readonly SkeletonSensor sensor;

        public SkeletonEventArgs(SkeletonSensor sensor)
        {
            this.sensor = sensor;
        }
    }
}
