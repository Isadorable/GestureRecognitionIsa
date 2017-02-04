using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Kinect
using Windows.Kinect;

namespace GestureForKinect.Recognition.FrameDataManager
{
    public class BodyIndexData : FrameData
    {
        /* Attributi */
        // Vettore che conterrà i dati contenuti nei BodyIndexFrame
        public byte[] pixels { get; private set; }
        
        /* Costruttore */
        /// <summary>
        /// Inizializza gli oggetti del BodyIndexData. Per farlo usa anche il costruttore del padre (per width e height).
        /// </summary>
        /// <param name="frameDescription"></param>
        public BodyIndexData(FrameDescription frameDescription) : base(frameDescription)
        {
            this.pixels = new byte[width * height];
        }


        internal void update(BodyIndexFrame bodyIndexFrame)
        {
            throw new NotImplementedException();
        }
    }
}
