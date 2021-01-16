using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float attack;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        transform.position = Vector3.Lerp(posA, posB, Time.deltaTime * 0.5f * speed);

        if (Vector3.Distance(posA, posB) < 1)
        {
            target.GetComponent<HeroBase>().Damage(attack);
            Destroy(gameObject);
        }
    }
}
