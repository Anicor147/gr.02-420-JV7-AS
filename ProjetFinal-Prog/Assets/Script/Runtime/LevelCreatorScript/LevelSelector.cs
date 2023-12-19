using UnityEngine;

namespace Script.Runtime.LevelCreatorScript
{
    public class LevelSelector : MonoBehaviour
    {
        private int _currentLevel = 0;

        public int CurrentLevel
        {
            get => _currentLevel;
            set => _currentLevel = value;
        }
    }
}
