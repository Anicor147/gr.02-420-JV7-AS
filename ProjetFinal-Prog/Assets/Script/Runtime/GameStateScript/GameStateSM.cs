using System.Collections.Generic;
using Script.Runtime.UIScript;
using UnityEngine;

namespace Script.Runtime.GameStateSM_Script
{
    public class GameStateSM : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenuCanvas;
        public static GameStateSM Instance { get; private set; }
        private Dictionary<string, GameState> _states = new();
        private GameState _currentState;


        public GameObject PauseMenuCanvas
        {
            get => _pauseMenuCanvas;
            set => _pauseMenuCanvas = value;
        }

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            _states.Add(nameof(GameOverSate), new GameOverSate(this));
            _states.Add(nameof(PausedState), new PausedState(this));
            _states.Add(nameof(PlayState), new PlayState(this));
            _currentState = _states[nameof(PlayState)];
            PauseMenuScript.onPress += ChangeToPlayState;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _currentState = new PausedState(this);
                _currentState.UpdateState();
            }
        }

        public void ChangeToPlayState()
        {
            _currentState = new PlayState(this);
            _currentState.UpdateState();
        }
    }
}
