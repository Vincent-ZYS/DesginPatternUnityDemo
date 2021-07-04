using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        //TODO
        Debug.Log("Gun shot!");
    }
}
