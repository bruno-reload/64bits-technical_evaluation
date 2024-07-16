using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirState : IState
{
    private IEntity enemy;
    private float angle = 0;

    public ChangeDirState(IEntity enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.Animator.Play("enemy_run");
        (enemy as EnemyController).Action.changeDir.Prepare();
    }

    public void Exit()
    {
        (enemy as EnemyController).Action.changeDir.Finished();
    }

    public void FixedUpdate()
    {
        (enemy as EnemyController).Action.changeDir.Perform();
    }

    public void Update()
    {
        (enemy as EnemyController).TryIdle();
        (enemy as EnemyController).TryRun();
    }
}
