﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Djestit
using GestureForKinect.Djestit;

namespace GestureForKinect.GestureManager.Gesture_Djestit
{
    class SkeletonStart : GroundTerm
    {
        /* Attributi */
        public int id { get; private set; }

        /* Costruttore */
        public SkeletonStart(int id) : base()
        {
            this.id = id;
            this.accepts = func_accepts;
        }

        /* Metodi */
        public bool func_accepts(Token token)
        {
            if (token.GetType() == typeof(SkeletonToken))
            {
                SkeletonToken skeletonToken = (SkeletonToken)token;

                if (skeletonToken.type != TypeToken.Start)
                    return false;
                if (this.id != skeletonToken.identifier)
                    return false;
                return true;
            }
            else
                return false;
        }
    }
}
