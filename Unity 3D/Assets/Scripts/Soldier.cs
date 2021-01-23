using UnityEngine;
using UnityEngine.AI;

public class Soldier : HeroBase
{
    public NavMeshAgent agent;
    public string targetName;
    public float stopDis = 3;
    public float attackRange = 20;
    public Vector3 attackOffset;
    public float attackLength = 3;


    public int enemyLayer;
    private Transform castle;
    private Transform target;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);

        Gizmos.color = new Color(1, 1, 0);
        Gizmos.DrawRay(transform.position + attackOffset, transform.forward * attackLength);
    }

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = hero.speed;
        agent.stoppingDistance = stopDis;
        castle = GameObject.Find(targetName).transform;
        target = castle;
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
        else
        {
            this.target = castle;
        }

        agent.SetDestination(this.target.position);
        canvasHP.eulerAngles = new Vector3(0, 90, 0);
        ani.SetBool("isRunning", agent.remainingDistance > agent.stoppingDistance);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (timer >= hero.cd)
        {
            ani.SetTrigger("attack");
            timer = 0;

            RaycastHit hit;
            if (Physics.Raycast(transform.position + attackOffset, transform.forward, out hit, attackLength, 1 << enemyLayer))
            {
                if (hit.collider.GetComponent<Tower>()) hit.collider.GetComponent<Tower>().Damage(hero.attack);
                if (hit.collider.GetComponent<Soldier>()) hit.collider.GetComponent<Soldier>().Damage(hero.attack);
            }
        }
        else
        {
            timer++;
        }
    }

    public override void Damage(float damage)
    {
        hp -= damage;
        textHP.text = hp.ToString();
        imgHP.fillAmount = hp / MAX_HP;

        if (hp <= 0)
        {
            Dead(false);
        }
    }
}
