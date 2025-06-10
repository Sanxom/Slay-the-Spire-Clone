using System.Collections.Generic;
using UnityEngine;

public class Perk
{
    public Sprite Image => data.Image;

    private readonly PerkData data;
    private readonly PerkCondition condition;
    private readonly AutoTargetEffect autoTargetEffect;

    public Perk(PerkData perkData)
    {
        data = perkData;
        condition = data.Condition;
        autoTargetEffect = data.AutoTargetEffect;
    }

    public void OnAdd()
    {
        condition.SubscribeCondition(Reaction);
    }

    public void OnRemove()
    {
        condition.UnsubscribeCondition(Reaction);
    }

    private void Reaction(GameAction gameAction)
    {
        if (condition.SubConditionIsMet(gameAction))
        {
            List<CombatantView> targets = new();
            if (data.UseActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
            {
                targets.Add(haveCaster.Caster);
            }
            if (data.UseAutoTarget)
            {
                targets.AddRange(autoTargetEffect.TargetMode.GetTargets());
            }

            GameAction perkEffectAction = autoTargetEffect.Effect.GetGameAction(targets, HeroSystem.Instance.HeroView);
            ActionSystem.Instance.AddReaction(perkEffectAction);
        }
    }
}