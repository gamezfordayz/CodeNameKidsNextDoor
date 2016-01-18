using UnityEngine;
using System.Collections;
using System;
using utils.timer;
using interfaces.ability;
using interfaces.cooldown;
using utils.notification;

namespace code.ability
{
    public class BaseAbility :IExecutable , ICooldown
    {
        #region Vars
        public string name = "";
        public string description = "";
        public Sprite image;
        public bool passive = false;
        public AbilityTypes type;

        float _coolDownTime = 0f;
        Timer _cooldown = null;
        #endregion

        #region Properties
        public bool OnCoolDown
        {
            get
            {
                if (_cooldown == null)
                {
                    _cooldown = new Timer(_coolDownTime, false);
                }
                return _cooldown.timerRunning;
            }
        }
        #endregion

        #region Methods
        public BaseAbility(float cooldown, string name, string description, Sprite image, AbilityTypes type, bool passive = false)
        {
            this._coolDownTime = cooldown; this.name = name; this.description = description; this.image = image; this.type = type; this.passive = passive;
            this._cooldown = new Timer(cooldown, false);
        }

        public virtual bool Execute()
        {
            if (!CheckIfCanExecute())
                return false;
            StartCoolDown(_coolDownTime);
            return true;
        }

        public virtual void OnExecute() { Debug.Log("Ability " + name + " was executed"); }

        public virtual bool CheckIfCanExecute()
        {
            if (OnCoolDown)
            {
                Notification.NotifyPlayer(NotificationType.OUT_OF_RESOURCE, name);
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
