using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mCharacterAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected IWeapon mWeapon;

    public IWeapon usingWeapon { set { mWeapon = value; } }

    public void Attack(Vector3 targetPosition)
    {
        mWeapon.Fire(targetPosition);
    }

}
