using UnityEngine;

namespace Script.Runtime.GameStateScript
{
    public class PlayState : GameState
    {
        public PlayState(GameStateSM gameStateSm) : base(gameStateSm) { }

        public override void UpdateState()
        {
            GameStateSM.Instance.PauseMenuCanvas.SetActive(false);
            GameStateSM.Instance.GameOverCanvas.SetActive(false);
            Time.timeScale = 1;
            base.UpdateState();
        }
    }
}
