using UnityEngine;

namespace Script.Runtime.GameStateSM_Script
{
    public class GameOverSate : GameState
    {
        public GameOverSate(GameStateSM gameStateSm) : base(gameStateSm) { }

        public override void UpdateState()
        {
            base.UpdateState();
            GameStateSM.Instance.GameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
