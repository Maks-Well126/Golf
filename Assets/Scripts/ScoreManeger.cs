using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManeger : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public int score { get; private set; }
        

        public void Increase()
        {
            score++;
            Debug.Log($"Score: {score}");
        }


        public void Reset()
        {
            score = 0;
        }
    }
}