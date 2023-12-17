using System;
using System.Collections.Generic;
using Script.Runtime.RuntimeScript;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> Hearth;
    [SerializeField] private Sprite[] hearthSprites;
    private int listIndex;
    private float maxHp = 20;
    private void Awake()
    {
        PlayerController.OnHpChange += UpdateHpBar;
        listIndex = Hearth.Count -1 ;
    }

    private void UpdateHpBar(float value)
    {
        maxHp += value;
        var tempHp = maxHp % 5;
    }
}
