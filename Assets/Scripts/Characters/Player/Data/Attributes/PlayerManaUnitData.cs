using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManaUnitData
{
    [field: SerializeField] public float Mana { get; set; } = 150f;
    [field: SerializeField] public float MaxMana { get; set; } = 150f;
}
