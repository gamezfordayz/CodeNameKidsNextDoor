using UnityEngine;
using System.Collections.Generic;
using code.stats;
using interfaces.general;
using code.baseCharacter;

namespace code.baseEnemy
{
    public abstract class BaseEnemy : BaseCharacter 
    {
        #region Var
        protected int level;
        #endregion

        #region Methods
        public BaseEnemy(Stats.StatTypes primaryStat = Stats.StatTypes.STRENGTH, int hp = 1, int def = 1, int str = 1, int agl = 1, int intellect = 1, int wis = 1, int level= 5)
        {
            this._primaryStat = primaryStat;
            int statTotal = hp + def + str + agl + intellect + wis;
            if (statTotal < level)
            {
                for (int i = 0; i < level - statTotal; i++)
                {
                    int statChoice = Random.Range(0,6);
                    switch(statChoice)
                    {
                        case 0: if (hp != 0) hp++; else i--; break;
                        case 1: if (def != 0) def++; else i--; break;
                        case 2: if (str != 0) str++; else i--; break;
                        case 3: if (agl != 0) agl++; else i--; break;
                        case 4: if (intellect != 0) intellect++; else i--; break;
                        case 5: if (wis != 0) wis++; else i--; break;
                        default: i--; break;
                    }
                }
            }
            characterStats = new Stats(hp, def, str, agl, intellect, wis);
          
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
        public override void Heal(int amount)
        {
            base.Heal(amount);
        }
        #endregion
    }
}
