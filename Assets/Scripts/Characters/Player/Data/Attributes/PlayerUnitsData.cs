using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerUnitsData
{
    [field: SerializeField] public PlayerHealthData HealthData {  get; private set; }
    [field: SerializeField] public PlayerManaUnitData ManaUnitData { get; private set;}
}
