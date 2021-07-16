using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttr
{
    protected string mCharacterName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected string mSpriteIconName;
    protected string mPrefabName;

    protected int mCurrentHP;
    protected int mLevel;
    protected int mDmgDescVal;
    protected float mCriticRate;//0~1 critic damage.
    //Once the level up, the soldier will improve their MaxHP, Damage Defend ability.
    // The Enemy would not level up, but still have critic damage.

    protected IAttrStrategy charAttrStrategy;
    //Can Set the specific strategy once the specific character is constructed.

    public ICharacterAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSpriteName, string prefabName)
    {
        mCharacterName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        charAttrStrategy = strategy;
        mSpriteIconName = iconSpriteName;
        mPrefabName = prefabName;
        mDmgDescVal = charAttrStrategy.GetDmgDescVal(mLevel);
        mCurrentHP = mMaxHP + charAttrStrategy.GetExtraHPVal(mLevel);
    }

    public int GetCurrentHP { get { return mCurrentHP; } }

    public int GetCrticDmg{ get { return charAttrStrategy.GetCriticDmg(mCriticRate); } }

    public void TakeDmgFromAttr(int damage) //The mDmgDescVal only need to initial at first time.
    {
        damage -= mDmgDescVal;
        if (damage <= 5) { damage = 5; }//fixed damage, limitation
        mCurrentHP -= damage;
    }
}
