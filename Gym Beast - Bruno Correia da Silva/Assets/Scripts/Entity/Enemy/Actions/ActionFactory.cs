using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class ActionFactory
    {
        public IAction idle;
        public IAction run;
        public IAction changeDir;
        public IAction dead;

        public ActionFactory(IEntity enemy)
        {
            idle = new IdleAction(enemy);
            run = new RunAction(enemy);
            changeDir = new ChangeDirAction(enemy);
            dead = new DeadAction(enemy);
        }
    }
}
