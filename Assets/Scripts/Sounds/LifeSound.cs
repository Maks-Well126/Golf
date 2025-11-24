using UnityEngine;

namespace Golf
{
    public class LifeSound : MonoBehaviour
    {
        [SerializeField] private AudioClip m_gainLifeClip;
        [SerializeField] private AudioClip m_loseLifeClip;

        private AudioSource m_audioSource;

        private void Awake()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        public void PlayGain()
        {
            if (m_gainLifeClip != null)
                m_audioSource.PlayOneShot(m_gainLifeClip);
        }

        public void PlayLose()
        {
            if (m_loseLifeClip != null)
                m_audioSource.PlayOneShot(m_loseLifeClip);
        }
    }
}
