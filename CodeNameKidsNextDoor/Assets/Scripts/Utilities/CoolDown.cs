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

        public CoolDown(float time)
        {
            CoolDownManager.Instance.StartCoroutine(CoolDownTimer(time));
        }

        IEnumerator CoolDownTimer(float time)
        {
            yield return new WaitForSeconds(time);
            if(TimerFinished != null)
                TimerFinished();
        }
    }
}
