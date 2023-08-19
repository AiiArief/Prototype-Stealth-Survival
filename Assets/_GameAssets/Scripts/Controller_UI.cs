using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SS
{
    public class Controller_UI : Controller
    {
        public static Controller_UI Instance;

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
                var statusStr = "Statuses : \n";
                foreach (var status in Controller_Player.Instance.Character.Statuses)
                    statusStr += status.Name + " - " + status.GenericValue + "\n";

                m_debugText.text =
                    string.Format("{0}:{1}:{2}", m_currentDateTime.Hour, m_currentDateTime.Minute, m_currentDateTime.Second) + " - " + Time.timeScale + "\n" +
                    statusStr;
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
