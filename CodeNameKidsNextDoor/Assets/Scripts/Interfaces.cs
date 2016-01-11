using UnityEngine;
using System.Collections;


namespace interfaces.general
{
    public interface IDamagable
    {
        void TakeDamage(int damage);
    }
    public interface IBreakAble
    {
        void Break();
    }
}
namespace interfaces.passive
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
        void OnExecute();
    }
   
}
