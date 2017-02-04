using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Djestit
using GestureForKinect.Djestit;
// Djestit Kinect
using GestureForKinect.GestureManager.Gesture_Djestit;
// JointInformation
using GestureForKinect.Recognition.BodyStructure;
// Kinect
using Windows.Kinect;
// Debug
using System.Diagnostics;
// Segment
using GestureForKinect.Feed;

namespace GestureForKinect.Recognition
{
    public class SensorInterface
    {
        // Attributi
        internal SkeletonSensor sensor;
        public int ciEntra =  0;

        public SensorInterface(AcquisitionManager am, Term expression)
        {
            //3 frame
            this.sensor = new SkeletonSensor(expression, 3);
            am.SkeletonsFrameManaged += updateSkeleton;
        }

        #region Update
        public void updateSkeleton(Skeleton[] skeletonList)
        {
            // Per ogni scheletro rilevato avvio il motorino
            foreach (Skeleton skeleton in skeletonList)
            {
                // Creo uno skeleton token
                SkeletonToken token = null;
                // Determino il tipo (Start, Move o End) e ne creo il token, e quindo lo genero
                if (skeleton.getStatus())
                {
                    if (sensor.checkSkeleton(skeleton.getIdSkeleton()))
                        token = (SkeletonToken)sensor.generateToken(TypeToken.Move, skeleton);
                    else
                        token = (SkeletonToken)sensor.generateToken(TypeToken.Start, skeleton);
                }
                else if (sensor.checkSkeleton(skeleton.getIdSkeleton()))
                {
                    token = (SkeletonToken)sensor.generateToken(TypeToken.End, skeleton);
                }

                // Se è stato creato un token, lo sparo al motore
                if (token != null)
                {
                    if (token.type != TypeToken.End)
                        this.sensor.root.fire(token);
                }

                // Se lo stato della choice è in error o complete allora lo riazzero
                if (this.sensor.root.state == expressionState.Error || this.sensor.root.state == expressionState.Complete)
                {
                    this.sensor.root.reset();
                }


            }
        }
        #endregion

    }
}
