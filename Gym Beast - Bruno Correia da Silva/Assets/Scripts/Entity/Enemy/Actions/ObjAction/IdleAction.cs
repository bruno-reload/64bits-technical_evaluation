using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : IAction
{
    private IEntity enemy;
    private float count;
    private System.Random random;

    public IdleAction(IEntity enemy)
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
        count -= Time.fixedDeltaTime;
    }

    public void Prepare()
    {
        Debug.Log("idle");
        count = Random.Range(8, 12);
    }

    public bool Rules()
    {
        count -= Time.fixedDeltaTime;
        return count < 0 && random.Next(0, 100) < 10;
    }
}
