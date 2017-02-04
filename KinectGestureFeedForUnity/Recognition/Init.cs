using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Kinect
using Windows.Kinect;

namespace GestureForKinect.Recognition
{
    public class Init
    {
        /// <summary>
        /// Provvede alla inizializzazione della variabile utilizzata per accedere ai 
        /// dati inviati dalla kinect
        /// </summary>
        /// <param name="kinectSensor"></param>
        public static KinectSensor Open(KinectSensor kinectSensor)
        {
            kinectSensor = KinectSensor.GetDefault();
            kinectSensor.Open();
            if (kinectSensor.IsAvailable == false)
                return kinectSensor;
            else
                throw new System.ArgumentException("Kinect not be connect.", "Connect the Kinect at PC");
        }

        /// <summary>
        /// Chiude la connessione con il dispositivo, e pone l'oggetto kinectSensor a null;
        /// </summary>
        /// <param name="kinectSensor"></param>
        public static void Close(KinectSensor kinectSensor)
        {
            kinectSensor.Close();
            kinectSensor = null;
        }

    }
}
