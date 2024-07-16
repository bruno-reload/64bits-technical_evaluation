using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateFactory : MonoBehaviour
    {
        public IState punch;
        public IState idle;
        public IState run;
        public IState getter;

        public StateFactory(IEntity player)
        {
            punch = new PunchState(player);
            idle = new IdleState(player);
            run = new RunState(player);
            getter = new GetterState(player);
        }
    }
}