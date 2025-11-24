using TMPro;
using UnityEngine;

namespace Golf.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class RecordText : MonoBehaviour
    {
        
        [SerializeField] private TMP_Text m_text;
        [SerializeField] private ScoreManeger m_scoreManeger;
        [SerializeField] private string m_format;
        
        private void OnValidate()
        {
            if (!m_text)
            {
                m_text = GetComponent<TMP_Text>();
            }
        }

        private void OnEnable()
        {  
            OnRecordChanged(m_scoreManeger.score);
            m_scoreManeger.RecordChanged += OnRecordChanged;
        }
           



        private void OnDisable() => 
            m_scoreManeger.RecordChanged -= OnRecordChanged;

       
        private void OnRecordChanged(int value)
        {
            m_format ??= string.Empty;
            m_text.text = string.Format( m_format, value.ToString());
        }
    }
}