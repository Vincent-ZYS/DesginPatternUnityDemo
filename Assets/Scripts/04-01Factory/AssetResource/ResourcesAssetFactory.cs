using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ResourcesAssetFactory : IAssetFactory
{
    private const string SoldierPrefabPath = "Characters/Soldier/";
    private const string EnemyPrefabPath = "Characters/Enemy/";
    private const string WeaponPrefabPath = "Weapons/";
    private const string EffectPreabPath = "Effects/";
    private const string AudioPath = "Audios/";
    private const string SpritePath = "Sprites/";
    public AudioClip LoadAudioClip(string name)
    {
        return NoNeedInitiateAsset(AudioPath + name) as AudioClip;
    }

    public GameObject LoadEffect(string name)
    {
        return NeedInitiateGo(EffectPreabPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return NeedInitiateGo(EnemyPrefabPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return NeedInitiateGo(SoldierPrefabPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        return NoNeedInitiateAsset(SpritePath + name) as Sprite;
    }

    public GameObject LoadWeapon(string name)
    {
        return NeedInitiateGo(WeaponPrefabPath + name);
    }

    private GameObject NeedInitiateGo(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if(o == null)
        {
            Debug.LogError("Can not load resource: " + path); return null;
        }
        return Object.Instantiate(o) as GameObject;
    }

    private Object NoNeedInitiateAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("Can not load resource: " + path); return null;
        }
        return o;
    }
}
