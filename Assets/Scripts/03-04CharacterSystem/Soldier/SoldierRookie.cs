using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRookie : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlaySoundEffect()
    {
        DoPlaySoundEffect("RookieDeath");
    }
}
