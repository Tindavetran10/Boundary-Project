using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerFlamingDragonRoarStrikeData
{
    [field: SerializeField] public GameObject Effect_FlameDestroyer { get; private set; }
    [field: SerializeField] public Vector3 Destination { get; set; }
    [field: SerializeField] public float Effect_Speed { get; set; } = 30f;
    [field: SerializeField] public float WaitingTImeSpawnVFX { get; set; } = 30f;

}
