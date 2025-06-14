using UnityEngine;

public class TargetRevealOnMove : MonoBehaviour
{
    public Transform player;         // •ŠÛ
    public GameObject targetCircle;  // ŠDF‚Ìœ
    public float revealDistance = 5f;

    private Vector3 startPos;
    private bool revealed = false;

    void Start()
    {
        startPos = player.position;
        targetCircle.SetActive(false); // Å‰‚Í”ñ•\Ž¦
    }

    void Update()
    {
        if (!revealed && Vector3.Distance(player.position, startPos) > revealDistance)
        {
            targetCircle.SetActive(true);
            revealed = true;
        }
    }
}
