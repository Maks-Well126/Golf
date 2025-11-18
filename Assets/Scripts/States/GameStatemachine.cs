using System;
using UnityEngine;

namespace Golf
{
    public class GameStatemachine : MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GameplayState m_gameplayState;

        private void Awake()
        {
            m_mainMenuState.Initialize(this);
            m_gameplayState.Initialize(this);
        }

        private void Start() => Enter<BootstrapState>();


        public void Enter<T>()
        {
            if (typeof(T) == typeof(BootstrapState))
            {
                m_mainMenuState.Enter();
            }

            if (typeof(T) == typeof(MainMenuState))
            {
                m_mainMenuState.Enter();
            }
            else if(typeof(T) == typeof(GameplayState))
            {
                m_gameplayState.Enter();
            }
        }
        
        
    }
}