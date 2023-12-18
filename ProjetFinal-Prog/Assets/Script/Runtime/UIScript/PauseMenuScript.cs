using System;
using UnityEngine;

namespace Script.Runtime.UIScript
{
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
}
