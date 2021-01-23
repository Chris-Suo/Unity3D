using UnityEngine;
using UnityEngine.AI;

public class Soldier : HeroBase
{
    public NavMeshAgent agent;
    public string targetName;
    public float stopDis = 3;
    public float attackRange = 20;

    public int enemyLayer;

    private Transform target;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = hero.speed;
        agent.stoppingDistance = stopDis;
        target = GameObject.Find(targetName).transform;
    }
    protected override void Update()
    {
        base.Update();
        Move(target);
    }

    protected override void Move(Transform target)
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, attackRange, 1 << enemyLayer);
        if (hit.Length > 0)
        {
            this.target = hit[0].transform;
        }

        agent.SetDestination(this.target.position);
        canvasHP.eulerAngles = new Vector3(0, 90, 0);
        ani.SetBool("isRunning", agent.remainingDistance > agent.stoppingDistance);

    }
}
