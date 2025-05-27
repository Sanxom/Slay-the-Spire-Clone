using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeroGA : GameAction
{
    public EnemyView Attacker { get; private set; }

    public AttackHeroGA(EnemyView attacker)
    {
        Attacker = attacker;
    }
}