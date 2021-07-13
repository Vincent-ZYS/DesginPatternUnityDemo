using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        //TODO
        Debug.Log("Rocket shot!");

        WeaponFireEffectActive("RocketShot", 0.1f, targetPosition, 0.4f);
    }
}
