using UnityEngine;
using TMPro;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManeger m_scoreManeger;
        
        [Header("UI")]
        [SerializeField] private TMP_Text m_scoreText; 

        private float m_time;
        private int m_currentMissedCount;
        private int m_score;

        private void Awake()
        {
            m_stoneSpawner = FindObjectOfType<StoneSpawner>();
        }

        private void Start()
        {
            m_time = m_spawnRate;
            m_currentMissedCount = m_missedCount;

            UpdateUI();
        }

        private void Update()
        { 
            
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
               Stone stone = m_stoneSpawner.Spawn();
               stone.Hit += OnHitStone;
               stone.Missed += OnMissed;
               m_time = 0;

            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            
            m_score++; 
            m_scoreManeger.Increase();
        }
        
        private void OnMissed(Stone stone)
        {
            UnsubscribeStone(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("GameOver");
            }
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }

        private void UpdateUI()
        {
            if (m_scoreText != null)
                m_scoreText.text = $"Score: {m_score}";
        }
    }

}
