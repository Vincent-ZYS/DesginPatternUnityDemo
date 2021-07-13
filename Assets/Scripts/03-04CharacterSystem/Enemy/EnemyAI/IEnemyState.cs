using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullStateID = 0,
    Attack,
    Chase
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;
    protected EnemyStateID mStateID;
    public EnemyStateID stateID { get { return mStateID; } }

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(EnemyTransition trans, EnemyStateID stateID)
    {
        if(trans == EnemyTransition.NullTransition)
        {
            Debug.Log("FSMState ERROR: NullTransition is not allowed for a real transition");
            return;
        }
        if (stateID == EnemyStateID.NullStateID)
        {
            Debug.Log("FSMState ERROR: NullStateID is not allowed for a real ID");
            return;
        }
        if(mMap.ContainsKey(trans))
        {
            Debug.LogError("FSMState ERROR: State " + mStateID.ToString() + " already has transition " + trans.ToString() +
                           "Impossible to assign to another state");
            return;
        }
        mMap.Add(trans, stateID);
    }

    public void DeletTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return;
        }
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("FSMState ERROR: Transition " + trans.ToString() + " passed to " + mStateID.ToString() +
                           " was not on the state's transition list");
        }
        mMap.Remove(trans);
    }

    public EnemyStateID GetOutPutStateID(EnemyTransition trans)
    {
        if(mMap.ContainsKey(trans))
        {
            return mMap[trans];
        }
        Debug.Log("FSMState ERROR: Transition" + trans.ToString() + " Not Existing or Null Reference!");
        return EnemyStateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }

    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter> targets);

    public abstract void Act(List<ICharacter> targets);
}
