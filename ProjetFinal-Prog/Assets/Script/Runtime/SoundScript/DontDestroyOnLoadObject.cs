using System;
using UnityEngine;

namespace Script.Runtime.SoundScript
{
    public class DontDestroyOnLoadObject : MonoBehaviour
    {
        public static DontDestroyOnLoadObject Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
