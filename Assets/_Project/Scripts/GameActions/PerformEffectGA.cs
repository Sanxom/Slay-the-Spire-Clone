using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformEffectGA : GameAction
{
    public Effect Effect { get; set; }

    public PerformEffectGA(Effect effect)
    {
        Effect = effect;
    }
}