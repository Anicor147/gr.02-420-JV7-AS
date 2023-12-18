using System;
using System.Collections.Generic;
using Script.Runtime.RuntimeScript;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearth;
    [SerializeField] private Sprite[] hearthSprites;
    private float _currentPlayerHp;
    
    private void Awake()
    {
        PlayerController.OnHpChange += UpdateHpBar;
    }

    private void Start()
    {
        _currentPlayerHp = GameObject.FindWithTag("Player").GetComponent<PlayerController>().CurrentHp;
    }

    private void UpdateHpBar(float value)
    {
        _currentPlayerHp += value;
        switch (_currentPlayerHp)
        {
            case <= 4:
                _hearth[0].GetComponent<Image>().sprite = hearthSprites[(int) _currentPlayerHp];
                _hearth[1].GetComponent<Image>().sprite = hearthSprites[0];
                _hearth[2].GetComponent<Image>().sprite = hearthSprites[0];
                _hearth[3].GetComponent<Image>().sprite = hearthSprites[0];
                _hearth[4].GetComponent<Image>().sprite = hearthSprites[0];
                break;
            case <= 8:
                 _hearth[0].GetComponent<Image>().sprite = hearthSprites[4];
                 _hearth[1].GetComponent<Image>().sprite = hearthSprites[(int) (_currentPlayerHp%5 + 1)];
                 _hearth[2].GetComponent<Image>().sprite = hearthSprites[0];
                 _hearth[3].GetComponent<Image>().sprite = hearthSprites[0];
                 _hearth[4].GetComponent<Image>().sprite = hearthSprites[0];
                break;
            case <= 12:
               _hearth[0].GetComponent<Image>().sprite = hearthSprites[4];
               _hearth[1].GetComponent<Image>().sprite = hearthSprites[4];
               _hearth[2].GetComponent<Image>().sprite = hearthSprites[(int) (_currentPlayerHp%9 + 1)];
               _hearth[3].GetComponent<Image>().sprite = hearthSprites[0];
               _hearth[4].GetComponent<Image>().sprite = hearthSprites[0];
                break;
            case <= 16:
                _hearth[0].GetComponent<Image>().sprite = hearthSprites[4];
                _hearth[1].GetComponent<Image>().sprite = hearthSprites[4];
                _hearth[2].GetComponent<Image>().sprite = hearthSprites[4];
                _hearth[3].GetComponent<Image>().sprite = hearthSprites[(int) (_currentPlayerHp%13 + 1)];
                _hearth[4].GetComponent<Image>().sprite = hearthSprites[0];
                break;
            case <= 20:
              _hearth[0].GetComponent<Image>().sprite = hearthSprites[4];
              _hearth[1].GetComponent<Image>().sprite = hearthSprites[4];
              _hearth[2].GetComponent<Image>().sprite = hearthSprites[4];
              _hearth[3].GetComponent<Image>().sprite = hearthSprites[4];
              _hearth[4].GetComponent<Image>().sprite = hearthSprites[(int) (_currentPlayerHp%17 + 1)];
                break;
        }
    }
}
