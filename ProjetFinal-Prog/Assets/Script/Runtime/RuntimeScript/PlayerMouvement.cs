using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    

    private void Update()
    {
        switch (Input.inputString)
        {
            case "d" :
                transform.position += Vector3.right;
                break;
            case "a":
                transform.position += Vector3.left;
                break;
            case "s":
                transform.position += Vector3.down;
                break;
            case "w":
                transform.position += Vector3.up;
                break;
        }
    }
}
