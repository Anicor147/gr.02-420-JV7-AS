using UnityEngine;


namespace Script.Runtime.ScriptableObjectScript
{
    [CreateAssetMenu(menuName = "SO/SoChickenData", fileName = "SoChickenDataScript", order = 0)]
    public class SoChickenDataScript : ScriptableObject
    {
        [SerializeField] private float _recoverHealth;

        public float RecoverHealth
        {
            get => _recoverHealth;
            set => _recoverHealth = value;
        }
    }
}
