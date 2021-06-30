using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStatusController controller) : base("02MainMenuScene", controller)
    {
    }

    private Button startGameBtn;

    public override void StateStart()
    {
        base.StateStart();
        startGameBtn = GameObject.Find("StartGame_btn").GetComponent<Button>();
        startGameBtn.onClick.AddListener(OnStartGameClick);
    }

    private void OnStartGameClick()
    {
        mController.SetState(new BattleState(mController), true);
    }
}
