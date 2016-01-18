using UnityEngine;
using System;
using System.Collections.Generic;

namespace utils.notification
{
    public static class Notification
    {
        #region Vars
        static Dictionary<NotificationType, string> _notifications = new Dictionary<NotificationType, string>();
        #endregion

        #region Methods
        static Notification()
        {
            _notifications.Add(NotificationType.OUT_OF_RESOURCE, "Out of Mana.");
            _notifications.Add(NotificationType.ON_COOLDOWN, " is on cooldown.");
        }

        public static void NotifyPlayer(NotificationType type, string name)
        {
            switch (type)
            {
                case NotificationType.ON_COOLDOWN:
                    Debug.Log(name + _notifications[type]);
                    break;
                case NotificationType.OUT_OF_RESOURCE:
                    Debug.Log(_notifications[type] + " Can not cast " + name);
                    break;
                default:
                    Debug.Log("UnHandled notification: " + Enum.GetName(typeof(NotificationType), type) +" " + name);
                    break;
            }
        }
        #endregion
    }

    public enum NotificationType
    {
        OUT_OF_RESOURCE, ON_COOLDOWN
    };
}
