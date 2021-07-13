using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : ICharacter
{
    protected EnemyFSMSystem mEnemyFSMSys;
    public IEnemy():base()
    {
        MakeFSM();
    }

    public void UpdateFSMAI(List<ICharacter> targets)
    {
        mEnemyFSMSys.GetCurrentState.Reason(targets);
        mEnemyFSMSys.GetCurrentState.Act(targets);
    }


    private void MakeFSM()
    {
        mEnemyFSMSys = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mEnemyFSMSys, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
        EnemyAttackState attackState = new EnemyAttackState(mEnemyFSMSys, this);
        chaseState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mEnemyFSMSys.AddStateToFSM(chaseState, attackState);
    }
}
