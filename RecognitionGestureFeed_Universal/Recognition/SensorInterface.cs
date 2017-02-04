﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Djestit
using RecognitionGestureFeed_Universal.Djestit;
// Djestit Kinect
using RecognitionGestureFeed_Universal.GestureManager.Gesture_Djestit;
// JointInformation
using RecognitionGestureFeed_Universal.Recognition.BodyStructure;
// Kinect
using Microsoft.Kinect;
// Debug
using System.Diagnostics;

namespace RecognitionGestureFeed_Universal.Recognition
{
    public class SensorInterface
    {
        // Attributi
        internal Sensor sensor;

        internal bool close(Token token)
        {
           
            if (token.GetType() == typeof(SkeletonToken))
            {
                SkeletonToken skeletonToken = (SkeletonToken)token;
                // La gesture inizia se l'utente chiude la mano destra
                if (skeletonToken.skeleton.rightHandStatus == HandState.Closed)
                {
                    return true;
                }
                else
                    return false;
            }
            return false;

        }
        internal bool moveX(Token token)
        {
            if (token.GetType() == typeof(SkeletonToken))
            {
                SkeletonToken skeletonToken = (SkeletonToken)token;
                // Controlla se la mano destra è effettivamente chiusa e se c'è stato un qualche movimento (anche impercettibile)
                // Preleva dall'ultimo scheletro il JointInformation riguardante la mano
                JointInformation jNew = skeletonToken.skeleton.getJointInformation(JointType.HandRight);
                List<float> listConfidenceX = new List<float>();
                List<float> listConfidenceY = new List<float>();
                // Calcolo la differenza lungo l'asse X e l'asse Y
                foreach(Skeleton sOld in skeletonToken.precSkeletons)
                {
                    // Preleva dal penultimo scheletro il JointInformation riguardante la mano
                    JointInformation jOld = skeletonToken.precSkeletons[0].getJointInformation(JointType.HandRight);
                    listConfidenceX.Add(Math.Abs(jNew.position.X - jOld.position.X));
                    listConfidenceY.Add(Math.Abs(jNew.position.Y - jOld.position.Y));
                }
                //Debug.WriteLine(listConfidenceX.Average() + " - " + listConfidenceY.Average());
                if (skeletonToken.skeleton.rightHandStatus == HandState.Closed && listConfidenceX.Average() > listConfidenceY.Average())
                    return true;
                else
                    return false;
            }
            return false;
        }
        internal bool moveY(Token token)
        {
            if (token.GetType() == typeof(SkeletonToken))
            {
                SkeletonToken skeletonToken = (SkeletonToken)token;
                // Controlla se la mano destra è effettivamente chiusa e se c'è stato un qualche movimento (anche impercettibile)
                // Preleva dall'ultimo scheletro il JointInformation riguardante la mano
                JointInformation jNew = skeletonToken.skeleton.getJointInformation(JointType.HandRight);
                List<float> listConfidenceX = new List<float>();
                List<float> listConfidenceY = new List<float>();
                // Calcolo la differenza lungo l'asse X e l'asse Y
                foreach (Skeleton sOld in skeletonToken.precSkeletons)
                {
                    // Preleva dal penultimo scheletro il JointInformation riguardante la mano
                    JointInformation jOld = skeletonToken.precSkeletons[0].getJointInformation(JointType.HandRight);
                    listConfidenceX.Add(Math.Abs(jNew.position.X - jOld.position.X));
                    listConfidenceY.Add(Math.Abs(jNew.position.Y - jOld.position.Y));
                }
                if (skeletonToken.skeleton.rightHandStatus == HandState.Closed && listConfidenceX.Average() < listConfidenceY.Average())
                    return true;
                else
                    return false;
            }
            return false;
        }
        internal bool open(Token token)
        {
            if (token.GetType() == typeof(SkeletonToken))
            {
                SkeletonToken skeletonToken = (SkeletonToken)token;
                // La gesture termina quando l'utente apre la mano destra
                if (skeletonToken.skeleton.rightHandStatus == HandState.Open)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public SensorInterface(AcquisitionManager am)
        {
            /* Pan Asse X */
            // Close
            GroundTerm termx1 = new GroundTerm();
            termx1.type = "Start";
            termx1.accepts = close;
            //termx1.Complete += Close;
            // Move
            GroundTerm termx2 = new GroundTerm();
            termx2.type = "Move";
            termx2.accepts = moveX;
            //termx2.Complete += Move;
            // Open
            GroundTerm termx3 = new GroundTerm();
            termx3.type = "End";
            termx3.accepts = open;
            //termx3.Complete += Open;
            Iterative iterativex = new Iterative(termx2);
            List<Term> listTermx = new List<Term>();
            listTermx.Add(iterativex);
            listTermx.Add(termx3);
            Disabling disablingx = new Disabling(listTermx);
            List<Term> listTermx2 = new List<Term>();
            listTermx2.Add(termx1);
            listTermx2.Add(disablingx);
            Sequence panX = new Sequence(listTermx2);
            panX.Complete += PanX;
            /* Pan Asse Y */
            // Close
            GroundTerm termy1 = new GroundTerm();
            termy1.type = "Start";
            termy1.accepts = close;
            //termy1.Complete += Close;
            // Move
            GroundTerm termy2 = new GroundTerm();
            termy2.type = "Move";
            termy2.accepts = moveY;
            //termy2.Complete += Move;
            // Open
            GroundTerm termy3 = new GroundTerm();
            termy3.type = "End";
            termy3.accepts = open;
            //termy3.Complete += Open;
            Iterative iterativey = new Iterative(termy2);
            List<Term> listTermy = new List<Term>();
            listTermy.Add(iterativey);
            listTermy.Add(termy3);
            Disabling disablingy = new Disabling(listTermy);
            List<Term> listTermy2 = new List<Term>();
            listTermy2.Add(termy1);
            listTermy2.Add(disablingy);
            Sequence panY = new Sequence(listTermy2);
            panY.Complete += PanY;

            List<Term> listTerm = new List<Term>();
            listTerm.Add(panX);
            listTerm.Add(panY);
            Choice choice = new Choice(listTerm);

            this.sensor = new Sensor(choice, 3);
            //am.OnFrameManaged += updateSkeleton;
        }

        public void updateSkeleton(AcquisitionManager am)
        {
            foreach(Skeleton skeleton in am.skeletonList)
            {
                SkeletonToken token = null;
                if (skeleton.getStatus())
                {
                    if (sensor.checkSkeleton(skeleton.getIdSkeleton()))
                    {
                        token = (SkeletonToken)sensor.generateToken(TypeToken.Move, skeleton);
                    }
                    else
                    {
                        token = (SkeletonToken)sensor.generateToken(TypeToken.Start, skeleton);
                    }
                }
                else if (sensor.checkSkeleton(skeleton.getIdSkeleton()))
                {
                    sensor.generateToken(TypeToken.End, skeleton);
                }
                

                if (token != null)
                {
                    this.sensor.root.fire(token);
                }

                if (this.sensor.root.state == expressionState.Error || this.sensor.root.state == expressionState.Complete)
                    this.sensor.root.reset();
            }
        }

        void PanX(object sender, GestureEventArgs t)
        {
            Debug.WriteLine("Pan X");
        }
        void PanY(object sender, GestureEventArgs t)
        {
            Debug.WriteLine("Pan Y");
        }
        void Close(object sender, GestureEventArgs t)
        {
            Debug.WriteLine("Ho la mano destra chiusa.");
        }
        void Move(object sender, GestureEventArgs t)
        {
            Debug.WriteLine("Ho mosso la mano destra.");
        }
        void Open(object sender, GestureEventArgs t)
        {
            Debug.WriteLine("Ho la mano destra aperta.");
        }

    }
}
