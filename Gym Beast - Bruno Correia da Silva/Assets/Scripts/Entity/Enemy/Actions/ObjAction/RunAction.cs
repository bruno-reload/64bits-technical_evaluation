using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class RunAction : IAction
    {
        private IEntity enemy;
        private float count;
        private float speed = 2f;
        private System.Random random;

        public RunAction(IEntity enemy)
        {
            this.enemy = enemy; 
            random = new System.Random(System.DateTime.Now.Millisecond + (enemy as EnemyController).GetInstanceID());
        }

        public void Finished()
        {
            count = Random.Range(8, 12);
        }

        public void Perform()
        {
            enemy.World.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            count -= Time.fixedDeltaTime;
        }

        public void Prepare()
        {
            Debug.Log("run");
            count = Random.Range(8, 12);
        }

        public bool Rules()
        { 
            count -= Time.fixedDeltaTime;
            return count < 0 && random.Next(0, 100) < 10;
        }
    }
}
