using UnityEngine;

namespace Script.Runtime.GameStateSM_Script
{
    public class GameOverSate : GameState
    {
        [SerializeField] private GameObject _gameOverCanvas;
        public GameOverSate(GameStateSM gameStateSm) : base(gameStateSm) { }

        public override void UpdateState()
        {
            base.UpdateState();
            Time.timeScale = 0;
            _gameOverCanvas.SetActive(true);
        }
    }
}
