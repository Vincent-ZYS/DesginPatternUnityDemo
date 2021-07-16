using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType wpType, Vector3 spawnPos, int lv = 1) where T : ICharacter, new()
    {
        throw new System.NotImplementedException();
    }
}
