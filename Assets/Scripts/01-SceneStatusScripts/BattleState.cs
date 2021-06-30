using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : ISceneState
{
    public BattleState(SceneStatusController controller) : base("03BattleScene", controller)
    {
    }

    public override void StateStart()
    {
        base.StateStart();
        GameFacade.Instance.Initiation();
    }

    public override void StateEnd()
    {
        base.StateEnd();
        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if(GameFacade.Instance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController), true);
        }
        GameFacade.Instance.Update();
    }
}
