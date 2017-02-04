using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

using GestureForKinect.Feed;

namespace GestureForKinect.Djestit
{
    //
    public delegate bool Accepts<T>(T token) where T : Token;

    public class GroundTerm : Term
    {
        public String type = "ground";
        public Accepts<Token> _accepts;
        public Accepts<Token> accepts;
        //segmento per la traccia del ground term
        public List<Segment> segments = new List<Segment>();

        //private qualcosa modality = null; per JS this.modality = undefined;

        public virtual bool _accepts2(Token token)
        {
            if(this._accepts != null) 
                return this._accepts(token); 
            else 
                return true;
        }

        public virtual bool accepts2(Token token)
        {
            if (this.accepts != null)
                return this.accepts(token);
            else
                return true;
        }

        public override bool lookahead(Token token)
        {
            return (this._accepts2(token) && this.accepts2(token));
        }

        public float totalLength()
        {
            float segmentsLength = 0;
            foreach (Segment s in this.segments)
            {
                segmentsLength += s.length;
            }
            return segmentsLength;
        }
    }
    
}
