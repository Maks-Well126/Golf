using System;
using UnityEngine;
using UnityEngine.UI;
namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {    
        [SerializeField] 
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_playButton;
        
        private GameStatemachine m_gameStateMachine;

        public void Initialize(GameStatemachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            m_playButton.onClick.AddListener(OnClicked);
        }

        public void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMachine.Enter<>();
        }
        
    }
}