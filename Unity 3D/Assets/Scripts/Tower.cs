using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 15;
    public float attackPower = 20;
    public GameObject bullet;
    public float speed = 100;
    public int layer;
    public float cd;
    private float timer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    private void Start()
    {
        timer = cd;
    }

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, attackRange, 1 << layer);

        if (hit.Length > 0)
        {
            if (timer >= cd)
            {
                GameObject temp = Instantiate(bullet, transform.position + transform.up * 10, Quaternion.identity);
                Bullet bulletIns = temp.AddComponent<Bullet>();
                bulletIns.target = hit[0].transform;
                bulletIns.speed = speed;
                bulletIns.attack = attackPower;

                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }



        }
    }
}
