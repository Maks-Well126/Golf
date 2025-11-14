using UnityEngine;

namespace old
{
    public class ItemSwitch : MonoBehaviour
    {
        [Header("Префабы предметов")]
        [SerializeField] private GameObject[] m_allItems;
        [Header("Предметы в руках")]
        [SerializeField] private GameObject[] m_currentitems;

        public void Switcher()
        {
            for (int i = 0; i < m_currentitems.Length; i++)
            {
                GameObject randomTool = m_allItems[Random.Range(0, m_allItems.Length)];
                m_currentitems[i] = ReplaceTool(m_currentitems[i], randomTool);
            }
        }


        private GameObject ReplaceTool(GameObject oldTool, GameObject randomTool)
        {
            Vector3 position = oldTool.transform.position;
            Quaternion rotation = oldTool.transform.rotation;
            Transform parent = oldTool.transform.parent;

            GameObject newTool = Instantiate(randomTool, position, rotation, parent);
            Destroy(oldTool);
            return newTool;
        }
    }
}