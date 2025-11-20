using UnityEngine;

  namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefabs;
        [SerializeField] private Stone[] m_bonusBall;
        [SerializeField] private Transform m_spawnPoint;

        public Stone Spawn()
        {
            Stone prefab;

            bool spawnBonus = m_bonusBall.Length > 0 && Random.value < 0.15f;

            if (spawnBonus)
            {
                prefab = m_bonusBall[Random.Range(0, m_bonusBall.Length)];
            }
            else
            {
                prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            }

            Stone stone = Instantiate(prefab, m_spawnPoint.position, m_spawnPoint.rotation);

            stone.IsBonus = spawnBonus;

            return stone;
        }
    }
}
