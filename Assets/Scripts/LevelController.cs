using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;


        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManeger m_scoreManeger;
        

        private float m_time;
        private List<Stone> m_stones;
        private int m_currentMissedCount;
        private int m_score;

        private void Awake()
        {   
            m_stones = new List<Stone>();
            
        }

        public void Initialize()
        {
            m_currentMissedCount = m_missedCount;
        }

        private void Update()
        { 
            
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
               Stone stone = m_stoneSpawner.Spawn();
               m_stones.Add(stone);
               stone.Hit += OnHitStone;
               stone.HitBonus += OnHitBonusStone;
               stone.Missed += OnMissed;
               m_time = 0;

            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);
            m_scoreManeger.Increase();
        }
        
        private void OnMissed(Stone stone)
        {
            UnsubscribeStone(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("GameOver");
                Finished?.Invoke();

                foreach(var item in m_stones)
                {
                    Destroy(item.gameObject);
                }

                m_stones.Clear();
            }
        }

        private void UnsubscribeStone(Stone stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
            stone.HitBonus -= OnHitBonusStone;
        }

        private void OnHitBonusStone(Stone stone)
        {
            UnsubscribeStone(stone);
            m_scoreManeger.AddBonus();   // +3 очка
        }


    }

}
