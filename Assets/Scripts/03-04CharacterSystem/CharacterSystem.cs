using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : IGameSystem
{

    List<ICharacter> mSoldiers = new List<ICharacter>();
    List<ICharacter> mEnemies = new List<ICharacter>();

    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        mEnemies.Add(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemies.Remove(enemy);
    }

    public override void Initiation()
    {
        throw new System.NotImplementedException();
    }

    public override void Release()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        UpdateSoldier();
        UpdateEnemy();
    }

    private void UpdateSoldier()
    {
        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.CharacterUpdate();
            soldier.UpdateFSMAI(mEnemies);
        }
    }

    private void UpdateEnemy()
    {
        foreach (IEnemy enemy in mEnemies)
        {
            enemy.CharacterUpdate();
            enemy.UpdateFSMAI(mSoldiers);
        }
    }
}
