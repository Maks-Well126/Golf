using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManeger m_scoreManeger;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;

        private GameStateMachine m_gameStatemachine;

        public void Initialize(GameStateMachine gameStatemachine)
        {
            m_scoreText.gameObject.SetActive(false);
            m_gameStatemachine = gameStatemachine;
        }

        public void Enter()
        {
            m_scoreManeger.Reset();
            m_scoreManeger.ScoreChanged += OnScoreChanged;

            m_scoreText.gameObject.SetActive(true);
            OnScoreChanged(m_scoreManeger.score);

            m_levelController.enabled = true;
            m_playerController.enabled = true;
        }

       

        public void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_scoreText.gameObject.SetActive(false);
        }

         private void OnScoreChanged(int score) => m_scoreText.text = score.ToString();
    }
}