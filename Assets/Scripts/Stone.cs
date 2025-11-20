using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        public event Action<Stone> HitBonus;
        public bool IsBonus { get; set; }

        private Rigidbody m_rigidbody;
       

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision other)
        {
           if (other.gameObject.GetComponent<Stick>())
    {
        if (IsBonus){
            Debug.Log("BONUS HIT!");
    
            HitBonus?.Invoke(this);
        }
        else
            Hit?.Invoke(this);

        return;
    }

    // Всё остальное — промах
        Missed?.Invoke(this);
        }

        public void AddForce(Vector3 power) => m_rigidbody.AddForce(power, ForceMode.Force);
    }
}
