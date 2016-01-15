using UnityEngine;
using System.Collections.Generic;
using code.stats;
using interfaces.general;
using code.baseCharacter;

public class BaseEnemy : MonoBehaviour
{
    #region Var
    public int hp, def, str, agl, intellect, wis;
    public int minLevel, maxLevel;


    protected float moveSpeed;
    protected float attackSpeed;
    protected float weightModifier; //weight between 0-1
     

    protected int level;
    protected float attackRange = 1;

    protected Stats.StatTypes primary;
    protected BaseCharacter enemyClass;
    protected GameObject player;

    #endregion

    #region Method 
    public virtual void Update()
    {
        bool agro = PlayerDetected();
        if (agro)
        {
            if (InRange(player.transform.position))
                Attack();
            else
                Move(player.transform.position); //chasePlayer
        }
        else
            Move();//move normal behavior


    }
    protected BaseCharacter EnemyCreation(Stats.StatTypes primaryStat = Stats.StatTypes.STRENGTH, int hp = 1, int def = 1, int str = 1, int agl = 1, int intellect = 1, int wis = 1, int level = 5)
    {
        primary = primaryStat;
        int statTotal = hp + def + str + agl + intellect + wis;
        if (statTotal < level)
        {
            for (int i = 0; i < level - statTotal; i++)
            {
                int statChoice = Random.Range(0, 6);
                switch (statChoice)
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
        return new BaseCharacter(primary, hp, def, str, agl, intellect, wis);
    }
    protected bool PlayerDetected()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 5)
        {
            return true;
        }
        else
        return false;
    }
    protected void Move(Vector3 target = default(Vector3))
    {
        //move to target using pathfinding
    }
    protected bool InRange(Vector3 target)
    {
        if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < attackRange)
            return true;
        else
        return false;
    }
    protected void Attack()
    {

    }

    #endregion 
}