using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    private void Update()
    {
        Track();
    }

    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime);
        transform.position = posB;
    }
}
