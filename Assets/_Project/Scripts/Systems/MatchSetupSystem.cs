using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    [SerializeField] private List<EnemyData> enemyDataList;
    [SerializeField] private int startingHandSize = 5;

    private void Start()
    {
        HeroSystem.Instance.Setup(heroData);
        EnemySystem.Instance.Setup(enemyDataList);
        CardSystem.Instance.Setup(heroData.Deck);
        DrawCardsGA drawCardsGA = new(startingHandSize);
        ActionSystem.Instance.Perform(drawCardsGA);
    }
}