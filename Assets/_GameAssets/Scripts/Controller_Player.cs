using UnityEngine;
using System.Collections;

namespace SS
{
    public class Controller_Player : Controller
    {
        public static Controller_Player Instance { get; private set; }

        public Character_Humanoid Character { get; private set; }

        [SerializeField] Rigidbody2D m_rb2D;
        [SerializeField] Transform m_spritesParent;

        [SerializeField] float m_walkSpeed = 1.0f;
        Vector2 m_movementInput;

        private void Awake()
        {
            Instance = this;

            Character = new Character_Humanoid(this);
        }

        private void Update()
        {
            var xInput = Input.GetAxisRaw("Horizontal");
            var yInput = Input.GetAxisRaw("Vertical");

            m_movementInput = new Vector2(xInput, yInput);

            var timeInputPrev = Input.GetKeyUp(KeyCode.Alpha1);
            var timeInputNext = Input.GetKeyUp(KeyCode.Alpha2);
            var timeInput = (timeInputNext) ? 1 : (timeInputPrev) ? -1 : 0;
            Time.timeScale = Mathf.Clamp(Time.timeScale + timeInput, 0, 2);
        }

        private void FixedUpdate()
        {
            m_rb2D.velocity = m_movementInput.normalized * m_walkSpeed;
            m_spritesParent.rotation = m_movementInput.magnitude > 0 ? Quaternion.Euler(0, 0, Mathf.Atan2(m_movementInput.y, m_movementInput.x) * (180 / Mathf.PI)) : m_spritesParent.rotation;
        }

    }
}
