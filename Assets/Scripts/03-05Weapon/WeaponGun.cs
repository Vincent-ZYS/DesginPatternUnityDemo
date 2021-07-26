﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun(int atkPower, float atkRange, GameObject weaponGo) : base(atkPower, atkRange, weaponGo)
    {
    }
    public override void Fire(Vector3 targetPosition)
    {
        //TODO
        Debug.Log("Gun shot!");

        WeaponFireEffectActive("GunShot", 0.05f, targetPosition, 0.1f);
    }
}
