using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCriticDmg(float criticRate)
    {
        return 0;
    }

    public int GetDmgDescVal(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHPVal(int lv)
    {
        return (lv - 1) * 10;
    }
}
