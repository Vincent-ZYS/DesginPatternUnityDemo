using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttr
{
    protected string mCharacterName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected int mCurrentHP;
    protected string mSpriteIconName;

    protected int mLevel;
    protected float mCriticDmg;//0~1 critic damage.
    //Once the level up, the soldier will improve their MaxHP, Damage Defend ability.
    // The Enemy would not level up, but still have critic damage.

    protected IAttrStrategy charAttrStrategy;
    //Can Set the specific strategy once the specific character is constructed.
}
