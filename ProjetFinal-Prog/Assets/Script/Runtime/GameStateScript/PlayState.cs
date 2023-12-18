using UnityEngine;

namespace Script.Runtime.GameStateSM_Script
{
    public class PlayState : GameState
    {
        public PlayState(GameStateSM gameStateSm) : base(gameStateSm) { }

        public override void UpdateState()
        {
            GameStateSM.Instance.PauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
            base.UpdateState();
        }
    }
}