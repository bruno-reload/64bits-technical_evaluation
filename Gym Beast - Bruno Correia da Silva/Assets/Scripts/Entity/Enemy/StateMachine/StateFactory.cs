using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class StateFactory
    {
        public IState move;
        public IState idle;
        public IState changeDir;
        public IState dead;

        public StateFactory(IEntity enemy) {
            move = new RunState(enemy);
            idle = new IdleState(enemy);
            changeDir = new ChangeDirState(enemy);
            dead = new DeadState(enemy);
        }
    }
}