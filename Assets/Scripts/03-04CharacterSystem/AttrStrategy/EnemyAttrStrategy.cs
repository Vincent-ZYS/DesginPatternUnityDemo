using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCriticDmg(float criticRate)
    {
        float randomNum = Random.Range(0, 1f);
        int finalCriticDmg = 0;
        if(randomNum <= criticRate)
        {
            finalCriticDmg = (int)(randomNum * 10f);
        }
        return finalCriticDmg;
    }

    public int GetDmgDescVal(int lv)
    {
        return 0;
    }

    public int GetExtraHPVal(int lv)
    {
        return 0;
    }
}
