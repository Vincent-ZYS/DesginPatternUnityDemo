using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mCharacterAttr;
    protected GameObject mCharacterGo;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnim;
    protected IWeapon mWeapon;

    public IWeapon usingWeapon { set { mWeapon = value; } }

    public float GetAtkRange { get { return mWeapon.AtkRange; } }

    public Vector3 characterPos
    {
        get
        {
            if (mCharacterGo != null)
            {
                return mCharacterGo.transform.position;
            }
            else
            {
                Debug.LogError("Target Character not Existing!");
            }
            return Vector3.zero;
        }
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);

    public void CharacterUpdate()
    {
        mWeapon.WeaponUpdate();
    }

    public void Attack(ICharacter target)
    {
        //Enable current character attack target.
        mWeapon.Fire(target.characterPos);
        mCharacterGo.transform.LookAt(target.characterPos);
        PlayAnimation("attack");
        UnderAttack(mWeapon.AtkDamage + mCharacterAttr.GetCrticDmg);
    }

    public virtual void UnderAttack(int damage) //Current Character is under attack.
    {
        mCharacterAttr.TakeDmgFromAttr(damage);
        //TODO Audio, animation and so on
        //Only Enemy has underAttack effect, particle effect
        //Only Soldier has attack audio, particle effect
    }

    public void GetKilled()
    {

    }

    protected void DoPlayEffect(string effectName)
    {
        //TODO Through the Resource management system to manage the resouces initiation.
        GameObject effectGo;
        //Use IEnumerator to control the effect objects' destroy.
    }

    protected void DoPlaySoundEffect(string clipName)
    {
        //TODO Through the Resource management system to manage the resouces initiation.
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
        //Use IEnumerator to control the effect objects' destroy.
    }
    public void PlayAnimation(string animName)
    {
        //Set the current animation for the current character
        mAnim.CrossFade(animName);
    }

    public void SetMoveTargetPosition(Vector3 targetPosition)
    {
        //Set target for the current character, then move.
        mNavAgent.SetDestination(targetPosition);
        PlayAnimation("move");
    }
}
