using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerLightAttackData
{
    [field: SerializeField] public GameObject VFX_LightAttack_Projectile { get; private set; }
    [field: SerializeField] public Vector3 Destination { get;  set; }
    [field: SerializeField] public float ProjectileSpeed { get; set; } = 30f;
    [field: SerializeField] public float WaitingTImeSpawnVFX { get; set; } = 30f;
}
