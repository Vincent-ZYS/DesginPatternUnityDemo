using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}
