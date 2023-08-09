using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SS
{
    public abstract class Character : MonoBehaviour
    {
        //[SerializeField] Rigidbody2D m_rb2D;
        //[SerializeField] Transform m_spritesParent;

        protected Dictionary<string, Status> m_statusDict;

        protected abstract void InitStatuses();

        protected virtual void OnEnable()
        {
            StartCoroutine(_HandleStatuses());
        }

        IEnumerator _HandleStatuses()
        {
            InitStatuses();

            while(true)
            {
                // update semua status
                yield return new WaitForSeconds(1.0f);
            }
        }

        //[SerializeField] float m_walkSpeed = 1.0f;
        //Vector2 m_movementInput;

        //private void Update()
        //{
        //    var xInput = Input.GetAxisRaw("Horizontal");
        //    var yInput = Input.GetAxisRaw("Vertical");

        //    m_movementInput = new Vector2(xInput, yInput);

        //    var timeInputPrev = Input.GetKeyUp(KeyCode.Alpha1);
        //    var timeInputNext = Input.GetKeyUp(KeyCode.Alpha2);
        //    var timeInput = (timeInputNext) ? 1 : (timeInputPrev) ? -1 : 0;
        //    Time.timeScale = Mathf.Clamp(Time.timeScale + timeInput, 0, 2);

        //}

        //private void FixedUpdate()
        //{
        //    m_rb2D.velocity = m_movementInput.normalized * m_walkSpeed;
        //    m_spritesParent.rotation = m_movementInput.magnitude > 0 ? Quaternion.Euler(0, 0, Mathf.Atan2(m_movementInput.y, m_movementInput.x) * (180 / Mathf.PI)) : m_spritesParent.rotation;
        //}
    }
}
