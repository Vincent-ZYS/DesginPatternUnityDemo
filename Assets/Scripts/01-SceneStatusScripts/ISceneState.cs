using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState
{
    private string mSceneName;
    public string GetSceneName { get { return mSceneName; } }

    protected SceneStatusController mController;

    public ISceneState(string sceneName, SceneStatusController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }

    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}
