using UnityEngine;
using System.Collections;
using interfaces.ability;
using System;

namespace code.ability
{
    public class BaseAbility 
    {
        public string name = "";
        public string description = "";
        public Sprite image;
        public bool executable = true;
        public AbilityTypes type;

        public BaseAbility(string name, string description, Sprite image, AbilityTypes type, bool executable)
        {
            this.name = name; this.description = description; this.image = image; this.type = type; this.executable = executable;
        }

    }

    public enum AbilityTypes
    { DAMAGING, HEALING, MODIFYING };
}
