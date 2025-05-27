using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsGA : GameAction
{
    public int Amount {  get; set; }

    public DrawCardsGA(int amount)
    {
        Amount = amount;
    }
}