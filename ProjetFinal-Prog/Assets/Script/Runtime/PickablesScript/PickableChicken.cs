using System;
using System.Collections;
using System.Collections.Generic;
using Script.Runtime.RuntimeScript;
using Script.Runtime.ScriptableObjectScript;
using UnityEngine;

public class PickableChicken : MonoBehaviour
{
    private Collider2D _collider2D;
    [SerializeField] private SoChickenDataScript _soChickenDataScript;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerController>().UpdateHp(_soChickenDataScript.RecoverHealth);
    }
}
