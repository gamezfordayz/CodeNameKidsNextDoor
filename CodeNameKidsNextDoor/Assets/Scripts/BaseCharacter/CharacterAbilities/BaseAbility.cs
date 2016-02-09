using UnityEngine;
using System.Collections;
using System;
using utils.timer;
using interfaces.ability;
using interfaces.cooldown;
using utils.notification;

namespace code.ability
{
    public class BaseAbility : MonoBehaviour, IExecutable , ICooldown
    {
        #region Vars
        public string abilityName = "";
        public string description = "";
        public Sprite image;
        public bool passive = false;
        public AbilityTypes type;

        [SerializeField]
        float _coolDownTime = 0f;
        Timer _cooldown = null;
        #endregion

        #region Properties
        public bool OnCoolDown
        {
            get
            {
                return _cooldown.timerRunning;
            }
        }
        public float TimeRemainingOnCooldown
        {
            get { return _cooldown.timeRemaining; }
        }
        public bool CanBeAssigned
        {
            get { return OnCoolDown; }
        }
        #endregion

        #region Methods
        void Start()
        {
            this._cooldown = new Timer(_coolDownTime, false);
        }

        //public BaseAbility(float cooldown, string name, string description, Sprite image, AbilityTypes type, bool passive = false)
        //{
        //    this._coolDownTime = cooldown; this.abilityName = name; this.description = description; this.image = image; this.type = type; this.passive = passive;
        //    this._cooldown = new Timer(cooldown, false);
        //}

        public virtual bool Execute()
        {
            if (!CheckIfCanExecute())
                return false;
            StartCoolDown(_coolDownTime);
            OnExecute();
            return true;
        }

        public virtual void OnExecute() { Debug.Log("Ability " + abilityName + " was executed"); }

        public virtual bool CheckIfCanExecute()
        {
            if (OnCoolDown)
            {
                Notification.NotifyPlayer(NotificationType.ON_COOLDOWN, abilityName);
                return false;
            }
            /*if(OutOfResource)
            {
                Notification.NotifyPlayer(NotificationType.ON_COOLDOWN, name);
                return false;
            }*/
            return true;
        }

        public virtual void StartCoolDown(float time)
        {
            if(this._cooldown.timeRemaining < time)
                this._cooldown.StartTimer(time);
        }

        #endregion

    }

    public enum AbilityTypes
    { DAMAGING, HEALING, MODIFYING };
}
