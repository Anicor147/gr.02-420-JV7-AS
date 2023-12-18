using System;
using UnityEngine;

namespace Script.Runtime.UIScript
{
    public class PauseMenuScript : MonoBehaviour
    {
        public static event Action OnPress;

        public void ReturnToGame()
        {
            OnPress?.Invoke();
        }

        public void BackToMenu()
        {
        
        }
    }
}
