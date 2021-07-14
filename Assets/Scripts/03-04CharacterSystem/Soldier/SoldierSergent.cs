using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSergent : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("SergentDeadEffect");
    }

    protected override void PlaySoundEffect()
    {
        DoPlaySoundEffect("SergentDeath");
    }
}
