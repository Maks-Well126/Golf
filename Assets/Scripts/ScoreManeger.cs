using System;
using UnityEngine;

namespace Golf
{
    
    public class ScoreManeger : MonoBehaviour
    {
        public void AddBonus() => score += 3;

        public event Action<int> ScoreChanged;
        public event Action<int> RecordChanged;

        private int m_score;

        public int score 
        { 
            get => m_score;
            private set
            {
                m_score = value;
                Debug.Log($"Score: {value}");
                ScoreChanged?.Invoke(value);
            }
        }

        public int record
        {
            get => PlayerPrefs.GetInt(GlobalConstans.Record, 0);
            private set
            {
                var temp = PlayerPrefs.GetInt(GlobalConstans.Record, 0);

                if (temp < value)
                {
                    PlayerPrefs.SetInt(GlobalConstans.Record, value);
                    RecordChanged?.Invoke(value);
                }
            }
        }

        public void Increase() => score++;
        
        public void UpdateRecord() => record = score;
        public void UpdateScore()
        {
            var record = PlayerPrefs.GetInt(GlobalConstans.Record, 0);

            if (record < score)
            {
                PlayerPrefs.SetInt(GlobalConstans.Record, score);
            }
        }


        public void Reset() => score = 0;
    }
}