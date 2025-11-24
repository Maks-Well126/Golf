using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using Golf.UI;



namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManeger m_scoreManeger;
        [SerializeField] private HeartController m_heartController;

        [SerializeField] private int m_startLives = 3;
        [SerializeField] private int m_maxLives = 5;
        

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

            m_currentMissedCount = m_startLives;
            m_heartController.Initialize(m_startLives, m_maxLives);
            ScreenFlash.Instance?.ResetFlash();
            
        }

        private void Update()
        { 
            
            m_time += Time.deltaTime;

            if (m_time >= m_spawnRate)
            {
               Stone stone = m_stoneSpawner.Spawn();
               m_stones.Add(stone);
               stone.Hit += OnHitStone;
               stone.Missed += OnMissed;
               m_time = 0;

            }
        }

        private void OnHitStone(Stone stone)
        {
            UnsubscribeStone(stone);

            if (stone.GivesLife)
            {
                m_heartController.AddLife();
                return;
            }

            m_scoreManeger.Increase(stone.score);
        }
        
        private void OnMissed(Stone stone)
        {
            UnsubscribeStone(stone);
            

            if (stone == null) return;


            if (stone.score < 0)
            {
                Destroy(stone.gameObject);
                return;
            }

            if (stone.IgnoreMiss)
            {
                Debug.Log("Miss ignored for this stone");
                return;
            }
    
            m_heartController.RemoveLife();


            if (m_heartController.GetLives() <= 0)
            {
                Debug.Log("GameOver");
                Finished?.Invoke();

                foreach (var item in m_stones)
                {
                    if (item != null)
                        Destroy(item.gameObject);
                }

                m_stones.Clear();
            }
        }

        private void UnsubscribeStone(Stone stone)
        {
            if (stone == null) return;

            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }


    }

}
