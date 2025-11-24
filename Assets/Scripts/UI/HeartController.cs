using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Golf.UI
{
    public class HeartController : MonoBehaviour
    {
        [SerializeField] private GameObject m_heartPrefab;
        [SerializeField] private Transform m_heartsContainer;
        [SerializeField] private LifeSound m_soundPlayer;


        private List<Image> m_hearts = new List<Image>();

        private int m_currentLives;
        private int m_maxLives;

        public void Initialize(int startLives, int maxLives)
        {
            m_currentLives = startLives;
            m_maxLives = maxLives;

            CreateHearts();   
            UpdateHearts();   
        }

        private void CreateHearts()
        {

            foreach (Transform child in m_heartsContainer)
                Destroy(child.gameObject);

            m_hearts.Clear();

            for (int i = 0; i < m_maxLives; i++)
            {
                GameObject heart = Instantiate(m_heartPrefab, m_heartsContainer);
                Image img = heart.GetComponent<Image>();

                m_hearts.Add(img);
            }
        }

        public void Reset(int startLives, int maxLives)
        {
            m_currentLives = startLives;
            m_maxLives = maxLives;

            CreateHearts();
            UpdateHearts();
        }

        public void AddLife()
        {
            if (m_currentLives < m_maxLives)
            {
                m_currentLives++;
                UpdateHearts();
                m_soundPlayer?.PlayGain();
            }
        }

        public void RemoveLife()
        {
            if (m_currentLives > 0)
            {
                m_currentLives--;
                UpdateHearts();
                m_soundPlayer?.PlayLose();
                ScreenFlash.Instance.Flash();
            }
        }

        public int GetLives() => m_currentLives;

        private void UpdateHearts()
        {
            for (int i = 0; i < m_hearts.Count; i++)
            {
                m_hearts[i].enabled = i < m_currentLives;
            }
        }
    }
}
