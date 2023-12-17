using System;
using System.Collections;
using System.Collections.Generic;
using Script.Runtime.RuntimeScript;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GorillaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        other.gameObject.GetComponent<PlayerController>().UpdateHp(-20);
    }
}
