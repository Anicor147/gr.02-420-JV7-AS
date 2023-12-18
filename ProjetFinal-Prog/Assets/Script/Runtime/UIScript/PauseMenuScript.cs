using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static event Action onPress;

    public void ReturnToGame()
    {
        onPress?.Invoke();
    }

    public void BackToMenu()
    {
        
    }
}
