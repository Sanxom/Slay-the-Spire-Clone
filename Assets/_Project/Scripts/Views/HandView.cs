using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class HandView : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private int maxHandSize = 10;
    [SerializeField] private float doTweenUpdatePositionDuration = 0.15f;
    [SerializeField] private float cardPositionOffset = 0.01f;

    private WaitForSeconds updateCardPositionTime;

    private List<CardView> cards = new();

    private void Awake()
    {
        updateCardPositionTime = new WaitForSeconds(doTweenUpdatePositionDuration);
    }

    public CardView RemoveCard(Card card)
    {
        CardView cardView = GetCardView(card);

        if (cardView == null) return null;

        cards.Remove(cardView);
        StartCoroutine(UpdateCardPositions(doTweenUpdatePositionDuration));
        return cardView;
    }

    public IEnumerator AddCard(CardView cardView)
    {
        cards.Add(cardView);
        yield return UpdateCardPositions(doTweenUpdatePositionDuration);
    }

    private IEnumerator UpdateCardPositions(float duration)
    {
        if (cards.Count == 0) yield break;

        float cardSpacing = 1f / maxHandSize;
        float firstCardPosition = 0.5f - (cards.Count - 1) * cardSpacing * 0.5f;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < cards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);
            cards[i].transform.DOMove(splinePosition + transform.position + cardPositionOffset * i * Vector3.back, duration);
            cards[i].transform.DORotate(rotation.eulerAngles, duration);
        }

        yield return updateCardPositionTime;
    }

    private CardView GetCardView(Card card)
    {
        return cards.Where(cardView => cardView.Card == card).FirstOrDefault();
    }
}