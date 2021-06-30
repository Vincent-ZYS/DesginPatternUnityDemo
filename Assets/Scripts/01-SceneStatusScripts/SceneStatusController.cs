using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStatusController
{
    private ISceneState mState;

    private AsyncOperation asyncOp;

    public bool isStateStart { get; set; } = false;

    public void SetState(ISceneState setState, bool isLoadScene)
    {
        if (mState != null)
        {
            //Clean the current state and ready to change to another state.
            mState.StateEnd();
        }
        mState = setState; 
        if(isLoadScene)
        {
            asyncOp = SceneManager.LoadSceneAsync(mState.GetSceneName);
            isStateStart = false;
        }
        else
        {
            mState.StateStart();
            isStateStart = true;
        }
    }

    public void StateUpdate()
    {
        if (asyncOp != null && !asyncOp.isDone) return;
        if(!isStateStart && asyncOp != null && asyncOp.isDone)
        {
            mState.StateStart();
            isStateStart = true;
        }
        if(mState != null)
        {
            mState.StateUpdate();
        }
    }
}
