using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    [CreateAssetMenu(fileName = "NewTrackData", menuName = "Indie-Pixel/Track Data/New Track Data", order = 1)]
    public class IP_Track_Data : ScriptableObject
    {
        #region Variables
        public float lastTrackTime;
        public float bestTrackTime;
        public float lastTrackScore;
        public float bestTrackScore;
        #endregion



        #region Custom Methods
        public void SetTimes(float aTime)
        {
            lastTrackTime = aTime;
            if(bestTrackTime == 0)
            {
                bestTrackTime = lastTrackTime;
            }
            else if(lastTrackTime < bestTrackTime)
            {
                bestTrackTime = lastTrackTime;
            }
        }

        public void SetScores(float aScore)
        {
            lastTrackScore = aScore;
            if(lastTrackScore > bestTrackScore)
            {
                bestTrackScore = lastTrackScore;
            }
        }
        #endregion
    }
}
