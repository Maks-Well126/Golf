using UnityEngine;
using Golf.Data;

namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;

        public Stone Spawn()
        {
            Stone prefab = GetWeightedStone();

            return Instantiate(prefab, m_spawnPoint.position, m_spawnPoint.rotation);
        }

        private Stone GetWeightedStone()
        {
            if (m_prefabs.Length == 0)
                return null;

            float totalWeight = 0f;

            foreach (var stone in m_prefabs)
                totalWeight += stone.GetData().spawnWeight;

            float rand = Random.value * totalWeight;

            foreach (var stone in m_prefabs)
            {
                rand -= stone.GetData().spawnWeight;
                if (rand <= 0f)
                    return stone;
            }

            return m_prefabs[m_prefabs.Length - 1];
        }
    }
}
