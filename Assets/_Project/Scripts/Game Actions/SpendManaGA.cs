using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpendManaGA : GameAction
{
    public int Amount { get; set; }

    public SpendManaGA(int amount)
    {
        Amount = amount;
    }
}