using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesTM : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return new(EnemySystem.Instance.Enemies);
    }
}