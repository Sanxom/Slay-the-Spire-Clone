using SerializeReferenceEditor;
using UnityEngine;

[System.Serializable]
public class AutoTargetEffect
{
    [field: SerializeReference, SR] public TargetMode TargetMode { get; private set; }
    [field: SerializeReference, SR] public Effect Effect { get; private set; }
}