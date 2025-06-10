using SerializeReferenceEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Perk")]
public class PerkData : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeReference, SR] public PerkCondition Condition { get; private set; }
    [field: SerializeReference, SR] public AutoTargetEffect AutoTargetEffect { get; private set; }
    [field: SerializeField] public bool UseAutoTarget { get; private set; } = true;
    [field: SerializeField] public bool UseActionCasterAsTarget { get; private set; } = false;
}