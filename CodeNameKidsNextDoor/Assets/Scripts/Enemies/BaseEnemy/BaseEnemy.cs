using UnityEngine;
using System.Collections;
using code.stats;
using interfaces.general;
using code.baseCharacter;

namespace code.baseEnemy
{
    public abstract class BaseEnemy : BaseCharacter 
    {
        #region Methods
        public BaseEnemy(Stats.StatTypes primaryStat = Stats.StatTypes.STRENGTH, int hp = 2, int def = 2, int str = 2, int agl = 2, int intellect = 0, int wis = 0)
        {
            this._primaryStat = primaryStat;
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
