using UnityEngine;

namespace Script.Runtime.GameStateScript
{
    public class PausedState : GameState
    {
        public PausedState(GameStateSM gameStateSm) : base(gameStateSm) { }

        public override void UpdateState()
        {
            GameStateSM.Instance.PauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
            base.UpdateState();
        }
    }
}
