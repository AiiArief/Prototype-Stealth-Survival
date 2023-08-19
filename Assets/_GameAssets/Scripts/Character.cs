using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SS
{
    public abstract class Character
    {
        public Controller Controller { get; protected set; }

        public List<Status> Statuses { get; protected set; }

        public Character()
        {
            Statuses = new List<Status>();
        }

        protected IEnumerator _HandleStatus()
        {
            while(true)
            {
                foreach (var status in Statuses)
                    status.UpdateStatus();

                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    public class Character_Humanoid : Character
    {
        public Character_Humanoid(Controller controller) : base()
        {
            Controller = controller;
            _SetupCharacter();

            Controller.StartCoroutine(_HandleStatus());
        }

        private void _SetupCharacter()
        {
            Statuses.Add(new Status_Warmth(36.5f, new MinMax(35, 38)));
            Statuses.Add(new Status_Hunger());
            Statuses.Add(new Status_Thirst());
        }
    }
}
