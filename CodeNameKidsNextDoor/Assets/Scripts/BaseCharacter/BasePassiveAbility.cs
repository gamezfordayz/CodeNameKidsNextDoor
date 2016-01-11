using UnityEngine;
using System.Collections;
using interfaces.passive;

public abstract class BasePassiveAbility : IPassive
{
    /*MAY NOT BE USED*/
    public abstract void OnPassivePickup();
    public abstract void OnPassiveDrop();
}
