using UnityEngine;

public interface IEntity
{
    public Animator Animator { get; }
    public StateMachine Machine { get; }
    public Transform World { get; }
}
