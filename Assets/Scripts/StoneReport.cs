using UnityEngine;

namespace Golf
{
    public class StoneReport : MonoBehaviour
    {
        private bool m_hasCollided = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (m_hasCollided)
                return;

            if (collision.collider.CompareTag("Stone"))
                return;

            if (collision.collider.CompareTag("Ground"))
            {
                Debug.Log("The stone hit the ground");
            }
            else if (collision.collider.CompareTag("Stick"))
            {
                Debug.Log("The stone hit the club");
            }

            m_hasCollided = true;
        }
    }
}
