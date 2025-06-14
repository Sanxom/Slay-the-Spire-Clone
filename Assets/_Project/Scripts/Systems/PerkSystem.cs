using System.Collections.Generic;
using UnityEngine;

public class PerkSystem : Singleton<PerkSystem>
{
    [SerializeField] private PerksUI perksUI;

    private readonly List<Perk> perks = new();

    public void AddPerk(Perk perk)
    {
        perks.Add(perk);
        perksUI.AddPerkUI(perk);
        perk.OnAdd();
    }

    public void RemovePerk(Perk perk)
    {
        perks.Remove(perk);
        perksUI.RemovePerkUI(perk);
        perk.OnRemove();
    }
}