using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        //TODO
        Debug.Log("Rifle shot!");

        WeaponFireEffectActive("RifleShot", 0.02f, targetPosition, 0.1f);
    }
}
