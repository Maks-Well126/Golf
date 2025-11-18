using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GameplayState : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManeger m_scoreManeger;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;
        public void Initialize(GameStatemachine gameStatemachine)
        {
            
        }
    }
}