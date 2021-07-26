using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType wpType, Vector3 spawnPos, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        string characterName = "Default";
        int maxHP = 10;
        float moveSpeed = 0.5f;
        string spriteIconName = "None";
        string prefabName = "None";

        System.Type t = typeof(T);
        if(t == typeof(SoldierCaptain))
        {
            characterName = "BigCaptain";
            maxHP = 150;
            moveSpeed = 3f;
            spriteIconName = "CaptainIcon";
            prefabName = "Soldier1";
        }else if(t == typeof(SoldierSergent))
        {
            characterName = "Sergent";
            maxHP = 100;
            moveSpeed = 2f;
            spriteIconName = "SergentIcon";
            prefabName = "Soldier3";
        }else if(t == typeof(SoldierRookie))
        {
            characterName = "Rookie";
            maxHP = 80;
            moveSpeed = 1.5f;
            spriteIconName = "RookieIcon";
            prefabName = "Soldier2";
        }else
         {
            Debug.LogError("The type of " + t + " is not belong to ISoldier type. Can Not create Character!");
            return null;
        }
        IAttrStrategy strategy = new SoldierAttrStrategy();
        ICharacterAttr attr = new SoldierAttr(strategy, characterName, maxHP, moveSpeed, spriteIconName, prefabName);
        character.SetCharacterAttr = attr;

        //Create Current Soldier Game Object: 1.Load Resources 2.Instantiation TODO
        GameObject characterGo = FactoryManager.GetAssetFactory.LoadSoldier(prefabName);
        character.CharacterGo = characterGo;
        characterGo.transform.position = spawnPos;
        //Add Weapon TODO
        character.usingWeapon = FactoryManager.GetWeaponFactory.CreateWeapon(wpType);

        return character;
    }
}
