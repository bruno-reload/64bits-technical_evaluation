using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Enemy
{
    public class ChangeDirAction : IAction
    {
        private IEntity enemy;
        private float count = 0;
        private System.Random random;
        public const float speedRotation = 50;
        private short direction = 1;
        private float angle = 0;

        public ChangeDirAction(IEntity enemy)
        {
            this.enemy = enemy;
            random = new System.Random(System.DateTime.Now.Millisecond + (enemy as EnemyController).GetInstanceID());
        }

        public void Finished()
        {
            count = Random.Range(12, 18);
        }

        public void Perform()
        {
            angle += direction * speedRotation * Time.fixedDeltaTime;
            enemy.World.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            count -= Time.fixedDeltaTime;
        }

        public void Prepare()
        {
            Debug.Log("change");
            count = Random.Range(8, 12);
            direction = Random.Range(0, 2) == 0 ? (short)1 : (short)-1;
        }

        public bool Rules()
        {
            count -= Time.fixedDeltaTime;
            return count < 0 && random.Next(0, 100) < 50;
        }
    }
}