using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SS
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;

        [SerializeField] bool m_debugMode = true;
        [SerializeField] Transform m_debugPanel;
        [SerializeField] Text m_debugText;

        DateTime m_currentDateTime;

        private void Awake()
        {
            Instance = this;

            m_currentDateTime = new DateTime(1,1,1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            StartCoroutine(_HandleDateTime());
        }

        private void Update()
        {
            m_debugPanel.gameObject.SetActive(m_debugMode);
            if (m_debugMode)
            {
                var needStr = "Needs : \n";
                foreach (var need in Character.Instance.Needs)
                    needStr += need.Name + " - " + need.CurrentPercentage + "\n";

                var statusEffectStr = "Status Effects : \n";
                foreach (var statusEffect in Character.Instance.StatusEffects)
                    statusEffectStr += statusEffect.Name + "\n";

                m_debugText.text = 
                    string.Format("{0}:{1}:{2}", m_currentDateTime.Hour, m_currentDateTime.Minute, m_currentDateTime.Second) + " - " + Time.timeScale + "\n" + 
                    needStr + "\n" + 
                    statusEffectStr;
            }
        }

        IEnumerator _HandleDateTime()
        {
            while(true)
            {
                yield return new WaitForSeconds(1.0f);
                m_currentDateTime = m_currentDateTime.AddSeconds(1);
            }
        }
    }
}
