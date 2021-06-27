using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{
    public StartState(SceneStatusController controller):base("01StartScene", controller)
    {
    }
    private Image logoImg;
    private float mSmoothRate = 0.5f;
    private float mChangeSceneTimer = 3f;
    public override void StateStart()
    {
        base.StateStart();
        logoImg = GameObject.Find("GameLogo_panel").GetComponent<Image>();
        logoImg.color = Color.black;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        FadeTitleLogo();
        ChangeNextScene();
    }

    private void FadeTitleLogo()
    {
        logoImg.color = Color.Lerp(logoImg.color, Color.white, mSmoothRate * Time.deltaTime);
    }

    private void ChangeNextScene()
    {
        mChangeSceneTimer -= Time.deltaTime;
        if(mChangeSceneTimer <= 0f)
        {
            mController.SetState(new MainMenuState(mController), true);
        }
    }
}
