using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStatusController controller) : base("02MainMenuScene", controller)
    {

    }

    public override void StateStart()
    {
        base.StateStart();
        Debug.LogError("Fuck Menu!");
    }
}
