using UnityEngine;
using System.Collections;
using System;

namespace utils.timer
{
    public class CoolDownManager : MonoBehaviour
    {
        static CoolDownManager _instance = null;

        public static CoolDownManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("No instance in CoolDownManager");
                    return null;
                }
                return _instance;
            }
        }

        static CoolDownManager()
        {
            _instance = new CoolDownManager();
        }

    }

    public class Timer
    {
        public event Action<float> TimerStarted;
        public event Action TimerFinished;

        public bool timerRunning = false;
        public float timeRemaining = 0.0f;

        Coroutine timer = null;

        public Timer(float time, bool start = true)
        {
            if(start)
                StartTimer(time);
        }

        public void StartTimer(float time)
        {
            timerRunning = true;
            timeRemaining = time;
            if(timer != null)
                CoolDownManager.Instance.StopCoroutine(timer);
            timer = CoolDownManager.Instance.StartCoroutine(CoolDownTimer(time));
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
    }
}
