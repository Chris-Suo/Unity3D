using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float attackRange = 15;
    public float attackPower = 20;
    public GameObject bullet;
    public float speed = 100;
    public int layer;
    public float cd;
    public float hp = 2000;

    private Transform canvasHP;
    private float MAX_HP;
    private Text textHP;
    private Image imgHP;
    private float timer;
    private bool isDead = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    private void Start()
    {
        timer = cd;
        MAX_HP = hp;
        canvasHP = transform.Find("Canvas");
        textHP = canvasHP.Find("BloodValue").GetComponent<Text>();
        textHP.text = hp.ToString();
        imgHP = canvasHP.Find("bloodValue").GetComponent<Image>();
    }

    private void Update()
    {
        if (isDead) return;
        Track();
    }

    public virtual void Damage(float damage)
    {
        hp -= damage;
        textHP.text = hp.ToString();
        imgHP.fillAmount = hp / MAX_HP;

        if (hp <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        gameObject.layer = 0;
        textHP.text = 0.ToString();
        imgHP.fillAmount = 0;
        isDead = true;
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
