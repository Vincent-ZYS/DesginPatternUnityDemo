using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();
    private ISoldierState mCurrentState;
    private SoldierStateID mCurrentStateID;
    public ISoldierState GetCurrentState { get { return mCurrentState; } }
    public SoldierStateID GetCurrentStateID { get { return mCurrentStateID; } }

    public void AddStateToFSM(params ISoldierState[] states)
    {
        foreach(ISoldierState s in states)
        {
            AddStateToFSM(s);
        }
    }

    public void AddStateToFSM(ISoldierState state)
    {
        if(state == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }
        if(mStates.Count <= 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentStateID = state.stateID;
            return;
        }
        foreach (ISoldierState stateItem in mStates)
        {
            if (stateItem.stateID == state.stateID)
            {
                Debug.LogError("FSM ERROR: Impossible to add state " + state.stateID.ToString() +
                               " because state has already been added");
                return;
            }
        }
        mStates.Add(state);
    }

    public void DeleteStateFromFSM(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
            return;
        }
        foreach(ISoldierState state in mStates)
        {
            if(state.stateID == stateID)
            {
                mStates.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: Impossible to delete state " + stateID.ToString() +
                       ". It was not on the list of states");
    }

    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
            return;
        }
        SoldierStateID stateID = mCurrentState.GetOutPutStateID(trans);
        if (stateID == SoldierStateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: State " + mCurrentState.ToString() + " does not have a target state " +
                           " for transition " + trans.ToString());
            return;
        }
        mCurrentStateID = stateID;
        foreach(ISoldierState stateItem in mStates)
        {
            if(stateItem.stateID == mCurrentStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = stateItem;
                mCurrentState.DoBeforeEntering();
                break;
            }
        }
    }
}
