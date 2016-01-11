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

    public class CoolDown
    {
        public event Action TimerFinished;

        float oldTimer = 0.0f;
        Coroutine timer = null;

        public CoolDown(float time)
        {
            StartTimer(time);
        }

        public void StartTimer(float time)
        {
            if(timer != null)
                CoolDownManager.Instance.StopCoroutine(timer);
            timer = CoolDownManager.Instance.StartCoroutine(CoolDownTimer(time));
        }

        IEnumerator CoolDownTimer(float time)
        {
            yield return new WaitForSeconds(time);
            if(TimerFinished != null)
                TimerFinished();
        }
    }
}
