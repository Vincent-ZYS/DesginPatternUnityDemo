using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptain : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlaySoundEffect()
    {
        DoPlaySoundEffect("CaptainDeath");
    }
}
