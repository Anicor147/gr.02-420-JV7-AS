using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Canvas _settingCanvas;
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LevelOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Prime");
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Additive);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(2);
        GameObject.FindWithTag("LevelSelect").GetComponent<LevelSelector>().CurrentLevel++;
        gameObject.SetActive(false);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        gameObject.SetActive(true);
    }

    public void OpenSetting()
    {
        _settingCanvas.gameObject.SetActive(true);
    }

    public void CloseSetting()
    {
        _settingCanvas.gameObject.SetActive(false);
    }
}
