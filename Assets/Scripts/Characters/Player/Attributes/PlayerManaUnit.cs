using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaUnit
{
    // Fields
    float _currentMana;
    float _currentMaxMana;
    public Player player;

    // Properties
    public float Mana
    {
        get { return _currentMana; }
        set { _currentMana = value; }
    }

    public float MaxMana
    {
        get { return _currentMaxMana;}
        set { _currentMaxMana = value; }
    }

    //Constructor
    public PlayerManaUnit(float mana, float maxMana)
    {
        _currentMana = mana;
        _currentMaxMana = maxMana;
    }

    #region Main Methods
    public void ManaConsumption(float manaAmount)
    {
        if (_currentMana > 0)
        {
            _currentMana -= manaAmount;
        }
    }

    public void ManaUnit()
    {
        if (player != null)
        {
            return;
        }
        if (_currentMana < _currentMaxMana)
        {
            _currentMana += 0.7f;
        }
        if ( _currentMana > _currentMaxMana)
        {
            _currentMana = _currentMaxMana;
        }
    }
    #endregion
}
