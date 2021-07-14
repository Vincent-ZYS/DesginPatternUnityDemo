using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState GetCurrentState { get { return mCurrentState; } }
    private EnemyStateID mCurrentStateID;
    public EnemyStateID GetCurrentStateID { get { return mCurrentStateID; } }

    public void AddStateToFSM(params IEnemyState[] states)
    {
        foreach(IEnemyState state in states)
        {
            AddStateToFSM(state);
        }    
    }

    public void AddStateToFSM(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }
        if(mStates.Count <= 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentStateID = state.stateID;
            state.DoBeforeEntering();
            return;
        }
        foreach(IEnemyState stateItem in mStates)
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

    public void DeleteStateFromFSM(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
            return;
        }
        foreach (IEnemyState state in mStates)
        {
            if (state.stateID == stateID)
            {
                mStates.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: Impossible to delete state " + stateID.ToString() +
                       ". It was not on the list of states");
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
            return;
        }
        EnemyStateID nxtStateID = mCurrentState.GetOutPutStateID(trans);
        if (nxtStateID == EnemyStateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: State " + mCurrentState.ToString() + " does not have a target state " +
                           " for transition " + trans.ToString());
            return;
        }
        mCurrentStateID = nxtStateID;
        foreach (IEnemyState stateItem in mStates)
        {
            if(stateItem.stateID == mCurrentStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = stateItem;
                mCurrentState.DoBeforeEntering();
            }    
        }
    }
}
