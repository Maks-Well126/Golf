using System;
using Golf.Data;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        [SerializeField] private StoneData m_data;

        private Rigidbody m_rigidbody;

        public int score { get; private set; }
        public bool GivesLife { get; private set; }
        public bool IgnoreMiss { get; private set; }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();

            score = m_data.score;
            IgnoreMiss = m_data.ignoreMiss;
            GivesLife = m_data.givesLife;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 power) => m_rigidbody.AddForce(power, ForceMode.Force);


        public StoneData GetData() => m_data;
    }
}
