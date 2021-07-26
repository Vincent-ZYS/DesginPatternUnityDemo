using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType wpType)
    {
        IAssetFactory assetFactory = FactoryManager.GetAssetFactory;
        IWeapon curWeapon = null;
        GameObject weaponGo = null;
        string wpName = "";
        switch (wpType)
        {
            case WeaponType.Gun:
                wpName = "WeaponGun";
                weaponGo = assetFactory.LoadWeapon(wpName);
                curWeapon = new WeaponGun(20, 5f, weaponGo);
                break;
            case WeaponType.Rifle:
                wpName = "WeaponRifle";
                weaponGo = assetFactory.LoadWeapon(wpName);
                curWeapon = new WeaponRifle(30, 7f, weaponGo);
                break;
            case WeaponType.Rocket:
                wpName = "WeaponRocket";
                weaponGo = assetFactory.LoadWeapon(wpName);
                curWeapon = new WeaponRocket(40, 8f, weaponGo);
                break;
        }
        return curWeapon;
    }
}
