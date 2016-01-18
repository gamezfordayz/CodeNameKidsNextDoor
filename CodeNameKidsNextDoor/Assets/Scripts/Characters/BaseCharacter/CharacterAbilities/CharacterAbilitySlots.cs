﻿using UnityEngine;
using System.Collections;
using code.ability;
using utils.timer;

public class CharacterAbilitySlots : MonoBehaviour
{
    #region Vars
    public float globalCD;
    public BaseAbility passiveAbility = null;

    BaseAbility[] _abilitySlots = new BaseAbility[4] {null ,null,null,null};
    Timer _globalCDTimer = null;
    #endregion

    #region Indexer
    BaseAbility this[int index]
    {
        get { return index == -1 ? passiveAbility : _abilitySlots[index]; }
        set { if (index == -1) passiveAbility = value; else { _abilitySlots[index] = value; }; }
    }
    #endregion

    #region Methods
    public void ExecuteAbility(int index)
    {
        if (this[index] != null && !_globalCDTimer.timerRunning)
        {
            if (this[index].Execute())
            {
                _globalCDTimer.StartTimer(globalCD);
            }
        }
    }

    public void PutAllAbilitysOnCooldown(float time)
    {
        foreach (BaseAbility temp in _abilitySlots)
        {
            temp.StartCoolDown(time);
        }
    }

    public bool AssignAbility(BaseAbility ability, int index)
    {
        if (this[index] == null || !this[index].CanBeAssigned)
        {
            this[index] = ability;
            return true;
        }
        return false;
    }
    #endregion
}
