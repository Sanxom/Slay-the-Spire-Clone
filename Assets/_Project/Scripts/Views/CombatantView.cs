using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatantView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeStrength;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    protected void SetupBase(int health, Sprite image)
    {
        MaxHealth = CurrentHealth = health;
        spriteRenderer.sprite = image;
        UpdateHealthText();
    }

    public void Damage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        transform.DOShakePosition(shakeDuration, shakeStrength);
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + CurrentHealth;
    }
}