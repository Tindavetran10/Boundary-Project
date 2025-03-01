using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUnit
{
    // Fields
    float _currentHealth;
    float _currentMaxHealth;

    
    public Player player;

    // Properties
    public float Health
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float MaxHealth
    {
        get { return _currentMaxHealth; }
        set { _currentMaxHealth = value; }
    }

    // Constructor
    public PlayerHealthUnit(float heathl, float maxHealth)
    {
        _currentHealth = heathl;
        _currentMaxHealth = maxHealth;
    }

    #region Main Methods
    public void DmgHealthUnit(float dmgAmount)
    {
        if (_currentHealth > 0 )
        {
            _currentHealth -= dmgAmount;
        }
    }

    public void HealUnit()
    {
        if (_currentHealth < _currentMaxHealth )
        {
            _currentHealth += 0.2f;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
    #endregion
}
