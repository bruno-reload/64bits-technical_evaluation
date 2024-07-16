using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private IEntity enemy;

    public IdleState(IEntity enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.Animator.Play("enemy_idle");
        (enemy as EnemyController).Action.idle.Prepare();
    }

    public void Exit()
    {
        (enemy as EnemyController).Action.idle.Finished();
    }

    public void FixedUpdate()
    {
        (enemy as EnemyController).Action.idle.Perform();
    }

    public void Update()
    {
        (enemy as EnemyController).TryChangeDir();
        (enemy as EnemyController).TryRun();
    }
}
