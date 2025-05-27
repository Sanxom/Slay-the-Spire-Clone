using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoardView : MonoBehaviour
{
    public List<EnemyView> EnemyViews { get; private set; } = new();

    [SerializeField] private List<Transform> slots;
    [SerializeField] private float removeEnemyScaleDuration = 0.25f;

    public void AddEnemy(EnemyData enemyData)
    {
        Transform slot = slots[EnemyViews.Count];
        EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(enemyData, slot.position, slot.rotation);
        enemyView.transform.parent = slot;
        EnemyViews.Add(enemyView);
    }

    public IEnumerator RemoveEnemy(EnemyView enemyView)
    {
        EnemyViews.Remove(enemyView);
        Tween tween = enemyView.transform.DOScale(Vector3.zero, removeEnemyScaleDuration);
        yield return tween.WaitForCompletion();
        Destroy(enemyView.gameObject);
    }
}