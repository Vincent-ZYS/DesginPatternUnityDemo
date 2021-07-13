using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade
{
    private static GameFacade _instance = new GameFacade();

    public static GameFacade Instance { get { return _instance; } }

    private bool mIsGameOver = false;
    public bool isGameOver { get { return mIsGameOver; } }

    private AchievementSystem mAchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Initiation()
    {
        mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mAchievementSystem.Initiation();
        mCampSystem.Initiation();
        mCharacterSystem.Initiation();
        mEnergySystem.Initiation();
        mGameEventSystem.Initiation();
        mStageSystem.Initiation();

        mCampInfoUI.Initiation();
        mGamePauseUI.Initiation();
        mGameStateInfoUI.Initiation();
        mSoldierInfoUI.Initiation();
    }

    public void Update()
    {
        mAchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        mAchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();
    }

    public Vector3 GetEnemyTargetPosition() //TODO, Get the Enemy's target position when Stage System Control.
    {
        return Vector3.zero;
    }
}
