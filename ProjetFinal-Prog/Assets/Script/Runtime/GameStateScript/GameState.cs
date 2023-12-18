namespace Script.Runtime.GameStateSM_Script
{
    public class GameState
    {
        protected GameStateSM _gameState;

        public GameState(GameStateSM gameStateSm)
        {
            _gameState = gameStateSm;
        }

        public virtual void UpdateState() { }
    }
}
