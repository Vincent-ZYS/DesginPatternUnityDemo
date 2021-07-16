using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAssetFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    GameObject LoadAudioClip(string name);
    GameObject LoadSprite(string name);
}
