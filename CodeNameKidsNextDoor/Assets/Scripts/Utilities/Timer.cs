using UnityEngine;
using System.Collections;
using System;

namespace utils.timer
{
    public class CoolDownManager : MonoBehaviour
    {
        #region Vars
        static CoolDownManager _instance = null;
        #endregion

        #region Properties
        public static CoolDownManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject temp = GameObject.Find("TimeManager");

                    if (temp == null)
                    {
                        temp = new GameObject("CoolDownManager", typeof(CoolDownManager));
                    }
                    _instance = temp.GetComponent<CoolDownManager>();
                }
                return _instance;
            }
        }
        #endregion
    }

    public class Timer
    {
        #region Events
        public event Action<float> TimerStarted;
        public event Action TimerFinished;
        #endregion

        #region Vars
        public bool timerRunning = false;
        public float timeRemaining = 0.0f;

        Coroutine _timer = null;
        #endregion

        #region Methods
        public Timer(float time, bool start = true)
        {
            if(start)
                StartTimer(time);
        }

        public void StartTimer(float time)
        {
            timerRunning = true;
            timeRemaining = time;
            if(_timer != null)
                CoolDownManager.Instance.StopCoroutine(_timer);
            _timer = CoolDownManager.Instance.StartCoroutine(CoolDownTimer(time));
        }

        IEnumerator CoolDownTimer(float time)
        {
            if (TimerStarted != null)
                TimerStarted(time);
            while (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                yield return null;
            }
            timerRunning = false;
            if(TimerFinished != null)
                TimerFinished();
        }
        #endregion

    }
}
