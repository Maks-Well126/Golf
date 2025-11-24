using System;
using System.Linq;
using Golf.Data;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        [SerializeField] private StoneData[] m_data;

        private Rigidbody m_rigidbody;
    
        public int score {get; private set;}
        public bool GivesLife { get; private set; }
        public bool IgnoreMiss { get; private set; }
       

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            var data = m_data[Random.Range(0, m_data.Length)];

            score = data.score;
            IgnoreMiss = data.ignoreMiss;
            GivesLife = data.givesLife;
            
            
        }

        private void OnCollisionEnter(Collision other)
        {
           
            if (other.gameObject.GetComponent<Stick>())
            {
                SoundManager.Instance.PlayHitSound();
                Hit?.Invoke(this);
            }
            else
            {
               Missed?.Invoke(this);
            }
           
        }

        public void AddForce(Vector3 power) => m_rigidbody.AddForce(power, ForceMode.Force);

        
    }
}
