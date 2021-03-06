using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private float AttackTimer = 1f;
    private float AttackTmRate = 1f;

    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Attack;
    }
    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            AttackTimer -= Time.deltaTime;
            if (AttackTimer <= 0)
            {
                //TODO Attack
                mCharacter.Attack(targets[0]);
                AttackTimer = AttackTmRate;
            }
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count <= 0)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
        }
        float targCharDistance = Vector3.Distance(targets[0].characterPos, mCharacter.characterPos);
        if (mCharacter.GetAtkRange < targCharDistance)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
        }
    }
}
