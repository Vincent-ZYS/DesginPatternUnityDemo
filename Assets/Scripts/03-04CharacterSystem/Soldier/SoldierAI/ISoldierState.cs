using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttackEnemy
}

public enum SoldierStateID
{
    NullStateID = 0,
    Idle,
    Attack,
    Chase
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM;
    protected SoldierStateID mStateID;
    public SoldierStateID stateID { get { return mStateID; } }

    public ISoldierState(SoldierFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(SoldierTransition trans, SoldierStateID stateID)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.Log("FSMState ERROR: NullTransition is not allowed for a real transition");
            return;
        }
        if(stateID == SoldierStateID.NullStateID)
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

    public void DeleteTransition(SoldierTransition trans)
    {
        // Check for NullTransition
        if (trans == SoldierTransition.NullTransition)
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

    public SoldierStateID GetOutPutStateID(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans))
        {
            return mMap[trans];
        }
        return SoldierStateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }

    public virtual void DoBeforeLeaving() { }

    public abstract void Reason(List<ICharacter> targets);

    public abstract void Act(List<ICharacter> targets);
}
