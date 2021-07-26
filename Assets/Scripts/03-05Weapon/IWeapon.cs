using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket
}

public abstract class IWeapon
{
    protected int mAtkPower;
    public int AtkDamage { get { return mAtkPower; } }

    protected float mAtkRange;
    public float AtkRange { get { return mAtkRange; } }
    protected int mExtraAtkPower;

    protected GameObject mWeaponGo;
    protected ICharacter mWeaponOwner;
    protected ParticleSystem mParticleEffect;
    protected LineRenderer mLineRdEffect;
    protected Light mLightEffect;
    protected AudioSource mAudio;

    protected float mEffectDisactiveTime = 0f;

    public ICharacter SetWeaponOwner { set { mWeaponOwner = value; } }

    public GameObject GetWeaponGo { get { return mWeaponGo; } }

    public IWeapon(int atkPower, float atkRange, GameObject weaponGo)
    {
        mAtkPower = atkPower;
        mAtkRange = atkRange;
        mWeaponGo = weaponGo;

        Transform weaponEffect = weaponGo.transform.Find("Effect");
        mParticleEffect = weaponEffect.GetComponent<ParticleSystem>();
        mLineRdEffect = weaponEffect.GetComponent<LineRenderer>();
        mLightEffect = weaponEffect.GetComponent<Light>();
        mAudio = weaponEffect.GetComponent<AudioSource>();
    }

    public void WeaponUpdate()
    {
        if(mEffectDisactiveTime > 0f)
        {
            mEffectDisactiveTime -= Time.deltaTime;
            if(mEffectDisactiveTime <= 0f)
            {
                //Disable specific components.
                mLightEffect.enabled = false;
                mLineRdEffect.enabled = false;
            }
        }
    }

    public abstract void Fire(Vector3 targetPosition);

    protected void WeaponFireEffectActive(string audioClip, float LRWidth, Vector3 targetPosition, float disactiveTime)
    {
        //Effect Disactive Time
        mEffectDisactiveTime = disactiveTime;

        //Gun shot Effect
        PlayShotEffect();

        //Gun shot bullet path
        PlayBulletEffect(LRWidth,targetPosition);

        //Gun shot Audio
        PlayAudioEffect(audioClip);

    }

    protected virtual void PlayShotEffect()
    {
        mParticleEffect.Stop();
        mParticleEffect.Play();
        mLightEffect.enabled = true;
    }

    protected virtual void PlayBulletEffect(float LRWidth, Vector3 targetPosition)
    {
        mLineRdEffect.enabled = true;
        mLineRdEffect.startWidth = LRWidth; mLineRdEffect.endWidth = LRWidth;
        mLineRdEffect.SetPosition(0, mWeaponGo.transform.position);
        mLineRdEffect.SetPosition(1, targetPosition);
    }

    protected virtual void PlayAudioEffect(string audioClip)
    {
        string clipName = audioClip;//"GunShot";
        AudioClip clip = null; //TODO Ready to use other resource loading method to load.
        mAudio.clip = clip;
        mAudio.Play();
    }
}
