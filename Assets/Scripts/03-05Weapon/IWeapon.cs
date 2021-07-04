using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon
{
    protected int mAtkPower;
    protected float mAtkRange;
    protected int mExtraAtkPower;

    protected GameObject mWeaponGo;
    protected ICharacter mWeaponOwner;
    protected ParticleSystem mParticleEffect;
    protected LineRenderer mLineRdEffect;
    protected Light mLightEffect;
    protected AudioSource mAudio;

    public abstract void Fire(Vector3 targetPosition);
}
