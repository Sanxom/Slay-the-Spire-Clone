using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageEffect : Effect
{
    [SerializeField] private int damageAmount;

    public override GameAction GetGameAction()
    {
        List<CombatantView> targets = new(EnemySystem.Instance.Enemies);
        DealDamageGA dealDamageGA = new(damageAmount, targets);
        return dealDamageGA;
    }
}