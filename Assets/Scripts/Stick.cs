using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {   
        [SerializeField] [Min(0)] private float m_power = 250f;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField] [Min(0)] private float m_speed;

        private bool m_isDown;
        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;

        private void FixedUpdate()
        {
            Vector3 angles = transform.localEulerAngles;

            if (m_isDown)
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }
            else
            {
                angles.z = Rotate(angles.z, m_minAngleZ);
            }

            transform.localEulerAngles = angles;
            
            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.localPosition;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.AddForce(m_power * m_direction);
            }
        }

        public void Down() => m_isDown = true;
        public void Up() => m_isDown = false;
        
     private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.fixedDeltaTime);
        }


   

       
    }
}
