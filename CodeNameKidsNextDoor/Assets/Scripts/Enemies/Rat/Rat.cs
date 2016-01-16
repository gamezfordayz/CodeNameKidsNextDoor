using UnityEngine;
using System.Collections.Generic;
using code.stats;
using interfaces.general;
using code.baseCharacter;


public class Rat : BaseEnemy
{
    #region vars
 
  

    

    #endregion

    public Sprite image;

	void Awake()
    {
        minLevel = 5; maxLevel = 8;
        primary = Stats.StatTypes.AGILITY;
        hp = 1; def = 1; str = 1; agl = 2; intellect = 0; wis = 0;
        level = Random.Range(minLevel, maxLevel + 1);
        enemyClass = EnemyCreation(primary,hp,def,str,agl,intellect,wis,level);
    }
	void Update ()
    {
      
	}
}
