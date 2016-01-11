using UnityEngine;
using System.Collections;
using code.ability;
using utils.timer;

public class CharacterAbilitySlots : MonoBehaviour
{
    BaseAbility[] _abilitySlots = new BaseAbility[4];
    BaseAbility _passiveAbility = null;
    CoolDown globalCD = null;

    public BaseAbility this[int index]
    {
        get { return index == 0 ? _passiveAbility : _abilitySlots[index]; }
        set { if (index == 0) _passiveAbility = value; else { _abilitySlots[index] = value; }; }
    }



}
