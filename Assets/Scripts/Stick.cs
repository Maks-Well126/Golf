using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {   
        [SerializeField] [Min(0)] private float m_power = 250;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField] [Min(0)] private float m_speed;
        
        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;

        private void FixedUpdate()
        {
            var angles = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angles.z = Rotate(angles.z, m_minAngleZ);
            }
            else
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;
            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.localPosition;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.GetComponent<Rigidbody>().AddForce(m_power * m_direction, ForceMode.Impulse);
            }
        }
    }
}
