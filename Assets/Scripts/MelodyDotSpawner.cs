using UnityEngine;

public class MelodyDotSpawner : MonoBehaviour
{
    public GameObject melodyDotPrefab;
    public float spawnInterval = 1.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMelodyDot();
            timer = 0f;
        }
    }

    void SpawnMelodyDot()
    {
        // ��ʊO�̏�i�����j�ɃX�|�[��������
        Camera cam = Camera.main;

        // Z�̓J��������̋����Ȃ̂ŁAZ=0�̃I�u�W�F�N�g���f���ɂ̓J������Z���l��
        float zDistance = Mathf.Abs(cam.transform.position.z);  // ��F10f

        // ��ʏ�̏����O���iY=1.1�j�ɃX�|�[��
        Vector3 viewportPos = new Vector3(0.5f, 1.1f, zDistance);
        Vector3 worldPos = cam.ViewportToWorldPoint(viewportPos);

        Instantiate(melodyDotPrefab, worldPos, Quaternion.identity);
    }
}
