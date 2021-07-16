using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterFactory
{
    ICharacter CreateCharacter<T>(WeaponType wpType, Vector3 spawnPos , int lv = 1) where T : ICharacter, new();
}
