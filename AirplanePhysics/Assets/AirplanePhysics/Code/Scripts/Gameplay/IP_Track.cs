using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


namespace IndiePixel
{
    public class IP_Track : MonoBehaviour
    {
        #region Variables
        [Header("Track Properties")]
        public IP_Track_Data trackData;
        public List<IP_Gate> gates = new List<IP_Gate>();

        [Header("Track Events")]
        public UnityEvent OnCompletedTrack = new UnityEvent();

        private float startTime;
        private int currentTime;
        #endregion


        #region Properties
        private int currentGateID = 0;
        public int CurrentGateID
        {
            get { return currentGateID; }
        }

        private int totalGates;
        public int TotalGates
        {
            get { return totalGates; }
        }

        private int currentMinutes;
        public int CurrentMinutes
        {
            get { return currentMinutes; }
        }

        private int currentSeconds;
        public int CurrentSecond
        {
            get { return currentSeconds; }
        }

        private int currentScore;
        public int CurrentScore
        {
            get { return currentScore; }
        }

        private bool isComplete = false;
        public bool IsComplete
        {
            set { isComplete = value; }
        }
        #endregion


        #region Builtin Methods
        // Use this for initialization
        void Start()
        {
            FindGates();
            InitializeGates();

            currentGateID = 0;
            StartTrack();
        }

        // Update is called once per frame
        void Update()
        {
            if(!isComplete)
            {
                UpdateStats();
            }
        }

        private void OnDrawGizmos()
        {
            FindGates();

            if(gates.Count > 0)
            {
                for(int i = 0; i < gates.Count; i++)
                {
                    if((i+1) == gates.Count)
                    {
                        break;
                    }

                    Gizmos.color = new Color(1f, 1f, 0, 0.5f);
                    Gizmos.DrawLine(gates[i].transform.position, gates[i + 1].transform.position);
                }
            }
        }
        #endregion


        #region Custom Methods
        public void StartTrack()
        {
            if(gates.Count > 0)
            {
                startTime = Time.time;
                currentScore = 0;
                isComplete = false;
                gates[currentGateID].ActivateGate();
            }
        }

        void SelectNextGate(float distPercentage)
        {
            int score = Mathf.RoundToInt(100f * (1f-distPercentage));
            score = Mathf.Clamp(score, 0, 100);
            currentScore += score;

            currentGateID++;
            if(currentGateID == gates.Count)
            {
                //Debug.Log("Completed Track!");
                if(OnCompletedTrack != null)
                {
                    OnCompletedTrack.Invoke();
                }
                return;
            }

            gates[currentGateID].ActivateGate();
        }

        void FindGates()
        {
            gates.Clear();
            gates = GetComponentsInChildren<IP_Gate>().ToList<IP_Gate>();
            totalGates = gates.Count;
        }

        void InitializeGates()
        {
            if(gates.Count > 0)
            {
                foreach(IP_Gate gate in gates)
                {
                    gate.DeactivateGate();
                    gate.OnClearedGate.AddListener(SelectNextGate);
                }
            }
        }

        void UpdateStats()
        {
            currentTime = (int)(Time.time - startTime);
            currentMinutes = (int)(currentTime / 60f);
            currentSeconds = currentTime - (currentMinutes * 60);
        }

        public void SaveTrackData()
        {
            if(trackData)
            {
                trackData.SetTimes(currentTime);
                trackData.SetScores(currentScore);
            }
        }
        #endregion
    }
}
