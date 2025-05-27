using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private readonly CardData data;

    public string Title { get; private set; }
    public string Description { get; private set; }
    public List<Effect> Effects { get; private set; }
    public Sprite Image { get; private set; }
    public int Mana { get; private set; }

    /// <summary>
    /// Initialization of a new generic Card based on its ScriptableObject
    /// </summary>
    /// <param name="cardData"></param>
    public Card(CardData cardData)
    {
        data = cardData;
        Image = data.Image;
        Title = data.Title;
        Description = data.Description;
        Mana = data.Mana;
        Effects = data.Effects;
    }
}