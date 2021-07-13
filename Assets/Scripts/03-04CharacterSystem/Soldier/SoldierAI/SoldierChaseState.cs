using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mCharacter.SetMoveTargetPosition(targets[0].characterPos);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets != null && targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float targCharDistance = Vector3.Distance(targets[0].characterPos, mCharacter.characterPos);
        if(mCharacter.GetAtkRange >= targCharDistance)
        {
            mFSM.PerformTransition(SoldierTransition.CanAttackEnemy);
            return;
        }
    }
}
