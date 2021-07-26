using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;

    public static IAssetFactory GetAssetFactory
    {
        get {
            if (mAssetFactory == null) { mAssetFactory = new ResourcesAssetFactory(); }
            return mAssetFactory;
        }
    }

    public static ICharacterFactory GetSoldierFactory
    {
        get
        {
            if (mSoldierFactory == null) { mSoldierFactory = new SoldierFactory(); }
            return mSoldierFactory;
        }
    }

    public static ICharacterFactory GetEnemyFactory
    {
        get
        {
            if (mEnemyFactory == null) { mEnemyFactory = new EnemyFactory(); }
            return mEnemyFactory;
        }
    }

    public static IWeaponFactory GetWeaponFactory
    {
        get
        {
            if (mWeaponFactory == null) { mWeaponFactory = new WeaponFactory(); }
            return mWeaponFactory;
        }
    }
}
