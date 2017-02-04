using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestureForKinect.Feed
{
    public class GestureSegments
    {
        public Dictionary<String, List<Segment>> gestureList {set; get;}

        public GestureSegments()
        {
            gestureList = new Dictionary<string,List<Segment>>();
        }

        public void addSegment(String name, Segment segment){
            List<Segment> listSegment;
            if(gestureList.ContainsKey(name))
            {
                gestureList.TryGetValue(name, out listSegment);
                listSegment.Add(segment);
            }
            else
            {
                listSegment = new List<Segment>();
                listSegment.Add(segment);
                gestureList.Add(name, listSegment);
            }
        }
    }
}
