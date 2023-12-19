using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
