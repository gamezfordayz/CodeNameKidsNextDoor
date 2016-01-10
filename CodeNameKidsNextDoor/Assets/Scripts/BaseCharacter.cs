using UnityEngine;
using System.Collections;
using code.stats;

namespace code.baseCharacter
{
    public class BaseCharacter
    {
        #region Vars
        Stats characterStats = null;
        #endregion

        #region Methods
        public BaseCharacter(int hp = 2, int def = 2, int str = 2, int agl = 2, int intellect = 2, int wis = 2)
        {
            characterStats = new Stats(hp, def, str, agl, intellect, wis);
        }
        #endregion
    }
}

