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

    public void Attack(ICharacter target)
    {
        //Enable current character attack target.
        mWeapon.Fire(target.characterPos);
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
    }
}
