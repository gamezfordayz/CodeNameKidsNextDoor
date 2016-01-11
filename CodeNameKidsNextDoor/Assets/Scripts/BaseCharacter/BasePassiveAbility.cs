using UnityEngine;
using System.Collections;
using interfaces.passive;

public abstract class BasePassiveAbility : IPassive
{
    bool hasActive = false;

    public BasePassiveAbility(bool hasActive = false) { this.hasActive = hasActive; }

    public abstract void OnPassivePickup();
    public abstract void OnPassiveDrop();
}
