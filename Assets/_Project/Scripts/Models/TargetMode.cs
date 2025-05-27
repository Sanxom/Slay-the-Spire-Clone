using System.Collections.Generic;

[System.Serializable]
public abstract class TargetMode
{
    public abstract List<CombatantView> GetTargets();
}