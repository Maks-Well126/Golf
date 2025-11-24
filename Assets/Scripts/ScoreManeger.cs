using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManeger : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public event Action<int> RecordChanged;

        private int m_score;

        public int score 
        { 
            get => m_score;
            private set
            {
                m_score = value;
                ScoreChanged?.Invoke(value);
            }
        }

        public int record
        {
            get => PlayerPrefs.GetInt(GlobalConstans.Record, 0);

            private set
            {
                if (record < value)
                {
                    PlayerPrefs.SetInt(GlobalConstans.Record, value);
                    PlayerPrefs.Save();       // ← важно для сохранения при выходе!
                    RecordChanged?.Invoke(value);
                }
            }
        }

        public void Increase(int value) => score += value;

        public void UpdateRecord() => record = score;

        public void Reset() => score = 0;
    }
}
