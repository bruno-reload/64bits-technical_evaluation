using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    private IEntity enemy;

    public RunState(IEntity enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.Animator.Play("enemy_run");
        (enemy as EnemyController).Action.run.Prepare();
    }

    public void Exit()
    {
        (enemy as EnemyController).Action.run.Finished();
    }

    public void FixedUpdate()
    {
        (enemy as EnemyController).Action.run.Perform();
    }

    public void Update()
    {
        (enemy as EnemyController).TryIdle();
        (enemy as EnemyController).TryChangeDir();
    }
}
