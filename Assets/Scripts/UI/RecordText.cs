using System;
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
            OnRecordChanged
        }

        public object OnRecordChanged { get; set; }

        private void OnDisable()
        {
          
        }
    }
}