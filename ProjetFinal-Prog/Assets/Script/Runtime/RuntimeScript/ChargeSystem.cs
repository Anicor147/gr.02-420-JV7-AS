using System;
using System.Collections;
using System.Collections.Generic;
using Script.Runtime.RuntimeScript;
using UnityEngine;

public class ChargeSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _numberOfCharge;

   
    void Start()
    {
        DestroyWall.OnChargeUpdate += ChargeUpdate;
    }

    public void ChargeUpdate(int obj)
    {
        _numberOfCharge[obj].SetActive(false);
    }
}
