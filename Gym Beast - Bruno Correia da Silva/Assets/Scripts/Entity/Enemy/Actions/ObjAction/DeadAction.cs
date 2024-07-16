using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class DeadAction : IAction
    {
        private IEntity enemy;
        private float count = 0;

        public DeadAction(IEntity enemy)
        {
            this.enemy = enemy;
        }

        public void Finished()
        {
        }

        public void Perform()
        {
        }

        public void Prepare()
        {
            (enemy as EnemyController).RagDoll.enableRagDoll();
        }

        public bool Rules()
        {
            return true;
        }
    }
}