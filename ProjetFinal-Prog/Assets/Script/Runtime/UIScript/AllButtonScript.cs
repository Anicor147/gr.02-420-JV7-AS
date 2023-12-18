using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   
    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
