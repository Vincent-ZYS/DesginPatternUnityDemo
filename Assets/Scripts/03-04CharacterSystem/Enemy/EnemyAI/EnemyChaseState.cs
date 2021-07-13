using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private Vector3 mTargetPosition;

    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character):base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }

    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mCharacter.SetMoveTargetPosition(targets[0].characterPos);
        }else
        {
            mCharacter.SetMoveTargetPosition(mTargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            //TODO Finish after Stage System implemented
            float targCharDistance = Vector3.Distance(targets[0].characterPos, mCharacter.characterPos);
            if(mCharacter.GetAtkRange >= targCharDistance)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
