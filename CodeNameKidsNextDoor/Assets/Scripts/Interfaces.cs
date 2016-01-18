﻿using UnityEngine;
using System.Collections;


namespace interfaces.general
{
    public interface IDamagable
    {
        void TakeDamage(int damage);
    }
    public interface IBreakable
    {
        void Break();
    }
}
namespace interfaces.ability
{
    public interface IPassive
    {
        void OnPassivePickup();
        void OnPassiveDrop();
    }
    public interface ITriggerable
    {
        // check for trigger?
        void OnTrigger();
    }
    public interface IExecutable
    {
        bool Execute();
        void OnExecute();
        bool CheckIfCanExecute();
    }
}

namespace interfaces.cooldown
{ 
    public interface ICooldown
    {
        void StartCoolDown(float time);
    }
   
}
