using UnityEngine;
using System.Collections;

namespace code.stats
{
    public class Stats
    {
        #region Vars
        int[] stats = new int[6];
        #endregion

        #region Indexer
        public int this[StatTypes type]
        {
            get { return stats[(int)type]; }
            set { stats[(int)type] = value; }
        }
        #endregion

        #region Methods
        public Stats(int hp, int def, int str, int agl, int intellect, int wis)
        {
            this[StatTypes.HEALTH] = hp; this[StatTypes.DEFENSE] = def; this[StatTypes.STRENGTH] = str; this[StatTypes.AGILITY] = agl; this[StatTypes.INTELLECT] = intellect; this[StatTypes.WISDOM] = wis;
        }

        public void ModifyStat(StatTypes type, int modifier)
        {
            this[type] = this[type] + modifier;
        }
        #endregion

        #region Stat Enums
        public enum StatTypes { HEALTH, DEFENSE, STRENGTH, AGILITY, INTELLECT, WISDOM };
        #endregion
    }
}
