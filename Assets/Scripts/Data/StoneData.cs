using UnityEngine;

namespace Golf.Data
{
    [CreateAssetMenu(fileName = "New StoneData", menuName = "StoneData")]
    public class StoneData : ScriptableObject
    {
        [SerializeField] private int m_score;
        [SerializeField] private bool m_ignoreMiss;
        [SerializeField][Range(0f, 100f)] private float m_spawnChance = 1f;
        [SerializeField] private bool m_givesLife;

        public int score =>m_score;
        public float spawnWeight => m_spawnChance;
        public bool ignoreMiss => m_ignoreMiss;
        public bool givesLife => m_givesLife;
    }

}