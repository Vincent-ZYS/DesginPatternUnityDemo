using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrStrategy
{
    int GetExtraHPVal(int lv);
    int GetDmgDescVal(int lv);
    int GetCriticDmg(float criticRate);//For Enemy
}
