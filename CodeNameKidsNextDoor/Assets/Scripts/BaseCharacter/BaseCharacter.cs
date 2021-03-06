﻿using UnityEngine;
using System;
using System.Collections;
using code.stats;
using interfaces.general;


namespace code.baseCharacter
{
    public class BaseCharacter : IDamagable
    {
        #region Vars
        protected Stats characterStats = null;
        protected Stats.StatTypes _primaryStat;
        protected Sprite characterSprite;
        protected int _maxHealth;
        protected int _currentHealth;
        #endregion

        #region Events
        public event Action OnHealthUp;
        public event Action OnTakeDamage;
        public event Action OnDeath;
        #endregion

        #region Properties
        public int PrimaryStat{ get { return characterStats[_primaryStat]; } }
        public int Health
        {
            get { return _currentHealth; }
            private set
            {
                _currentHealth = value;
                _currentHealth = (int)Mathf.Min(_currentHealth, _maxHealth);
                if (_currentHealth <= 0) OnDeath(); 
            }
        }
        public bool CanBeDamaged { get { if(!IsDying) return true;return false; } }// need impimentation for global cd on damaged? 
        public bool IsDying { get { return _currentHealth <= 0; } }
        public bool IsHealthMax { get { return _currentHealth == _maxHealth; } }
        #endregion

        #region Methods
        public BaseCharacter(Stats.StatTypes primaryStat = Stats.StatTypes.STRENGTH,int hp = 2, int def = 2, int str = 2, int agl = 2, int intellect = 2, int wis = 2)
        {
            this._primaryStat = primaryStat;
            characterStats = new Stats(hp, def, str, agl, intellect, wis);
        }
        public virtual void TakeDamage(int damage)
        {
            if (CanBeDamaged)
            {
                OnTakeDamage();
                Health -= damage;
            }
        }
        public virtual void Heal(int amount)
        {
            if (!IsHealthMax)
            {
                if(OnHealthUp != null)
                    OnHealthUp();
                Health += amount;
            }
        }
        #endregion
    }
}

