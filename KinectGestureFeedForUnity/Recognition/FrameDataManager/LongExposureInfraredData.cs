﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Kinect
using Windows.Kinect;

namespace GestureForKinect.Recognition.FrameDataManager
{
    public class LongExposureInfraredData : InfraredData
    {
        /* Attributi */
        public TimeSpan relativeTime { get; private set; }

        /* Costruttore */
        public LongExposureInfraredData(FrameDescription frameDescription) : base(frameDescription)
        {

        }
        
        /* Metodi */
        /// <summary>
        /// Aggiorna il contenuto dell'InfraredData (ovvero dell'array frameData) 
        /// </summary>
        /// <param name="frame"></param>
        public void update(LongExposureInfraredFrame frame)
        {
            // Aggiorno i valori frameData con quelli contenuti nell'ultimo frame inviato dal sensore.
            frame.CopyFrameDataToArray(this.frameData);
            this.relativeTime = frame.RelativeTime;
        }
    }
}
