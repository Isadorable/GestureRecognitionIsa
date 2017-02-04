using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//La classe Segment rappresenta il singolo segmento che rappresenterà il tracciato della gesture
namespace GestureForKinect.Feed
{
    public class Segment
    {
        //possiede una lunghezza e una inclinazione (
        //public int size { set; get; }
        public float length { set; get; }
        //l'inclinazione nella retta è costante per ogni segmento mentre nella curva cambia per ogni segmento (angolo in gradi)
        public float angle { set; get; }

        public Segment(float length, float angle)
        {
            //this.size = size;
            this.length = length;
            this.angle = angle;
        }



    }
}
