using System;
using System.Reflection;
using Golf.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private Stone[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;

        public Stone Spawn()
        {
            if (m_prefabs == null || m_prefabs.Length == 0)
            {
                return null;
            }

            if (m_spawnPoint == null)
            {
                return null;
            }

            // Логируем веса каждого префаба и считаем общую сумму
            float totalWeight = 0f;
            for (int i = 0; i < m_prefabs.Length; i++)
            {
                var p = m_prefabs[i];
                if (p == null)
                {
                    Debug.Log($"Prefab #{i} is null");
                    continue;
                }

                float w = GetPrefabTotalWeight(p);
                Debug.Log($"Prefab #{i}: '{p.name}' weight = {w}");
                totalWeight += w;
            }

            float r = Random.Range(0f, totalWeight);

            float acc = 0f;
            for (int i = 0; i < m_prefabs.Length; i++)
            {
                var p = m_prefabs[i];
                if (p == null) continue;

                float w = GetPrefabTotalWeight(p);
                acc += w;
                if (r < acc)
                {
                    Debug.Log($"Chosen prefab: #{i} '{p.name}' (acc={acc})");
                    return Instantiate(p, m_spawnPoint.position, m_spawnPoint.rotation);
                }
            }

            for (int i = m_prefabs.Length - 1; i >= 0; i--)
            {
                if (m_prefabs[i] != null)
                {
                    Debug.Log($"Fallback spawn: '{m_prefabs[i].name}'");
                    return Instantiate(m_prefabs[i], m_spawnPoint.position, m_spawnPoint.rotation);
                }
            }

            return null;
        }

        private float GetPrefabTotalWeight(Stone prefab)
        {
            if (prefab == null) return 0f;

            Type t = prefab.GetType();

            FieldInfo fi = t.GetField("m_data", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null && typeof(Array).IsAssignableFrom(fi.FieldType))
            {
                try
                {
                    var arr = fi.GetValue(prefab) as StoneData[];
                    if (arr != null)
                    {
                        float sum = 0f;
                        foreach (var d in arr)
                        {
                            if (d == null) continue;
                            sum += Mathf.Max(0f, d.spawnWeight);
                        }
                        return sum;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogWarning($"Error reading m_data from prefab '{prefab.name}': {e.Message}");
                }
            }

            // 3) Фоллбек: 0
            return 0f;
        }
    }
}
