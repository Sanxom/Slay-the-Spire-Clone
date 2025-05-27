using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageGA : GameAction
{
    public List<CombatantView> Targets { get; set; }
    public int Amount { get; set; }

    public DealDamageGA(int amount, List<CombatantView> targets)
    {
        Amount = amount;
        Targets = new(targets);
    }
}