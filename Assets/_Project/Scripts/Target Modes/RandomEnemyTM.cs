using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyTM : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        CombatantView target = EnemySystem.Instance.Enemies[UnityEngine.Random.Range(0, EnemySystem.Instance.Enemies.Count)];
        return new() { target };
    }
}