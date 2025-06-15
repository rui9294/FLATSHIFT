using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
    public GameObject shadowPrefab;
    public float spawnInterval = 0.1f;
    public float minMoveDistance = 0.01f; // ˆê’èˆÈã“®‚¢‚½‚Æ‚«‚¾‚¯o‚·

    private float timer = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(transform.position, lastPosition) > minMoveDistance)
        {
            if (timer >= spawnInterval)
            {
                SpawnShadow();
                timer = 0f;
                lastPosition = transform.position;
            }
        }
    }

    void SpawnShadow()
    {
        GameObject shadow = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
    }
}
