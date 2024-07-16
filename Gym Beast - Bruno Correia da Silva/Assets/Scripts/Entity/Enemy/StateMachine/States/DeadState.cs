using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private IEntity enemy;

    public DeadState(IEntity enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        (enemy as EnemyController).Action.dead.Prepare();
    }

    public void Exit()
    {
        (enemy as EnemyController).Action.dead.Finished();
    }

    public void FixedUpdate()
    {
        (enemy as EnemyController).Action.dead.Perform();
    }

    public void Update()
    {
        
    }
}
