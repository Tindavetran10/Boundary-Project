using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerHealthData
{
    [field: SerializeField] public float Health { get; set; } = 100f;
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
}
