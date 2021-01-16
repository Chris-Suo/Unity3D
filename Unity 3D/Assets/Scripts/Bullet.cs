using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        transform.position = Vector3.Lerp(posA, posB, Time.deltaTime * 0.5f * speed);

    }
}
