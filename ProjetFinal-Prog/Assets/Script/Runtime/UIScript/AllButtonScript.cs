using Script.Runtime.LevelCreatorScript;
using Script.Runtime.RuntimeScript;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Runtime.UIScript
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private Canvas _settingCanvas;
        [SerializeField] private GameObject _buttonNextLvl;

        public void MainMenuButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
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
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().CurrentHp = 100;
            GameObject.FindWithTag("Player").GetComponent<DestroyWall>().NumberOfCharge = 3;
            gameObject.SetActive(true);
            if (GameObject.FindWithTag("LevelSelect").GetComponent<LevelSelector>().CurrentLevel == 3)
            {
                _buttonNextLvl.SetActive(false);
            }
        }

        public void OpenSetting()
        {
            _settingCanvas.gameObject.SetActive(true);
        }
    }
}
