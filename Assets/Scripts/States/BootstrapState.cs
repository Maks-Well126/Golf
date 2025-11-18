using System;
using UnityEngine;

namespace Golf
{
    public class BootstrapState : MonoBehaviour
    {
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;
        
        
        private GameStatemachine m_gameStateMachine;

        public void Initialize(GameStatemachine gameStateMachine)
        {
           m_levelController.enabled = false;
           m_playerController.enabled = false;
           
           m_gameStateMachine = gameStateMachine;
        }
        
        
    }
}