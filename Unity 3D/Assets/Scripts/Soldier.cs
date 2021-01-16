using UnityEngine;
using UnityEngine.AI;

public class Soldier : HeroBase
{
    public NavMeshAgent agent;
    public Transform target;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = hero.speed;
    }
    protected override void Update()
    {
        base.Update();
        Move(target);
    }

    protected override void Move(Transform target)
    {
        agent.SetDestination(target.position);
    }
}
