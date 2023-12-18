using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Runtime.SoundScript
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioMainMenu;
        [SerializeField] private AudioClip _audioLevel1;
        [SerializeField] private AudioClip _audioLevel2;
        [SerializeField] private AudioClip _audioLevel3;
        [SerializeField] private Slider _musicSlider;
        private AudioSource _audioSource;
        private Scene _currentScene;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _currentScene = SceneManager.GetActiveScene();
        }
        
        private void ChangeAudioSourceClip()
        {
            if (_currentScene.name != "MainMenu")
            {
                switch ("Level" + GameObject.FindWithTag("LevelSelect").GetComponent<LevelSelector>().CurrentLevel)
                {
                    case "Level1":
                        _audioSource.clip = _audioLevel1;
                        break;
                    case "Level2":
                        _audioSource.clip = _audioLevel2;
                        break;
                    case "Level3":
                        _audioSource.clip = _audioLevel3;
                        break;
                }
            }
            else if (_currentScene.name == "MainMenu")
            {
                _audioSource.clip = _audioMainMenu;
            }

            _audioSource.Play();
        }
    }
}
