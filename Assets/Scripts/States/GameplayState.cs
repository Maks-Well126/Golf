using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GamePlayState : StateBase
    {   [SerializeField] private GameObject m_gameplayPanel;
        
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManeger m_scoreManeger;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;

        private GameStateMachine m_gameStatemachine;

        public override void Initialize(GameStateMachine gameStatemachine)
        {   
            m_gameplayPanel.SetActive(false);
            m_gameStatemachine = gameStatemachine;
        }

        public override void Enter()
        {
            m_scoreManeger.Reset();
            m_scoreManeger.ScoreChanged += OnScoreChanged;

            OnScoreChanged(m_scoreManeger.score);
            m_gameplayPanel.SetActive(true);
            

            m_levelController.enabled = true;
            m_playerController.enabled = true;

            m_levelController.Initialize();
            m_levelController.Finished += OnFinished;
        }

        private  void OnFinished() => m_gameStatemachine.Enter<GameOverState>();

        public override void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_scoreText.gameObject.SetActive(false);
            m_levelController.Finished -= OnFinished;
        }

         private void OnScoreChanged(int score) => m_scoreText.text = score.ToString();
    }
}