using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private TMP_Text mana;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;
    [SerializeField] private LayerMask dropAreaLayer;

    public Card Card { get; private set; }

    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;

    private readonly float cardHoverYOffset = -2f;
    private readonly float mousePositionZValue = -1f;
    private readonly float mouseUpRaycastDistance = 10f;

    public void Setup(Card card)
    {
        Card = card;
        title.text = Card.Title;
        description.text = Card.Description;
        mana.text = Card.Mana.ToString();
        imageSR.sprite = Card.Image;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanHover()) return;

        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanHover()) return;

        Vector3 pos = new(transform.position.x, cardHoverYOffset, 0);
        CardViewHoverSystem.Instance.Show(Card, pos);
        wrapper.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanInteract()) return;

        if (Card.ManualTargetEffect != null)
        {
            ManualTargetingSystem.Instance.StartTargeting(MouseUtils.GetMousePositionInWorldSpace(mousePositionZValue));
        }
        else
        {
            Interactions.Instance.PlayerIsDragging = true;
            wrapper.SetActive(true);
            CardViewHoverSystem.Instance.Hide();
            dragStartPosition = transform.position;
            dragStartRotation = transform.rotation;
            transform.SetPositionAndRotation(MouseUtils.GetMousePositionInWorldSpace(mousePositionZValue), Quaternion.Euler(0, 0, 0));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanInteract()) return;

        if (Card.ManualTargetEffect != null)
        {
            EnemyView target = ManualTargetingSystem.Instance.EndTargeting(MouseUtils.GetMousePositionInWorldSpace(mousePositionZValue));
            if (target != null && ManaSystem.Instance.HasEnoughMana(Card.Mana))
            {
                PlayCardGA playCardGA = new(Card, target);
                ActionSystem.Instance.Perform(playCardGA);
            }
        }
        else
        {
            PlayCardOrResetPosition();

            Interactions.Instance.PlayerIsDragging = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanInteract()) return;
        if (Card.ManualTargetEffect != null) return;

        transform.position = MouseUtils.GetMousePositionInWorldSpace(mousePositionZValue);
    }

    private bool CanPlayCard()
    {
        return ManaSystem.Instance.HasEnoughMana(Card.Mana) && Physics.Raycast(transform.position, Vector3.forward, out _, mouseUpRaycastDistance, dropAreaLayer);
    }

    private void PlayCardOrResetPosition()
    {
        if (CanPlayCard())
        {
            PlayCardGA playCardGA = new(Card);
            ActionSystem.Instance.Perform(playCardGA);
        }
        else
        {
            transform.SetPositionAndRotation(dragStartPosition, dragStartRotation);
        }
    }
}