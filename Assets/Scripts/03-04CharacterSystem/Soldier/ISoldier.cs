using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISoldier : ICharacter
{
    protected SoldierFSMSystem mSoldierFSMSys;

    //TODO The construct function
    public ISoldier():base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        mSoldierFSMSys.GetCurrentState.Reason(targets);
        mSoldierFSMSys.GetCurrentState.Act(targets);
    }

    private void MakeFSM()
    {
        mSoldierFSMSys = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(mSoldierFSMSys, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mSoldierFSMSys, this);
        chaseState.AddTransition(SoldierTransition.CanAttackEnemy, SoldierStateID.Attack);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);

        SoldierAttackState attackState = new SoldierAttackState(mSoldierFSMSys, this);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);

        mSoldierFSMSys.AddStateToFSM(idleState, chaseState, attackState);
    }
}
