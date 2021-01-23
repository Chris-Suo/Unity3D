using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawn;
    public Transform point;
    public float interval = 5;
    public int count = 4;

    private int currentCount = 0;

    private void Generate()
    {
        if (currentCount < count)
        {
            Instantiate(spawn, point.position, point.rotation);
            Invoke("Generate", 0.5f);
            currentCount++;
        }
        else
        {
            currentCount = 0;
        }


    }

    private void Start()
    {
        InvokeRepeating("Generate", 0, interval);
    }
}
