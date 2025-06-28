using UnityEngine;

public class PlayerDotCollision : MonoBehaviour
{
    [SerializeField] private AudioSource seSource;  // ���ʉ��Đ��p AudioSource
    [SerializeField] private AudioClip passSE;      // ����ԂŒʉ߂����Ƃ���SE

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MelodyDot"))
        {
            MelodyDotState dotState = other.GetComponent<MelodyDotState>();
            if (dotState != null)
            {
                if (dotState.IsPassable())
                {
                    Debug.Log("����ԁF�ʉ�OK");

                    // ���ʉ���炷
                    if (seSource != null && passSE != null)
                    {
                        seSource.PlayOneShot(passSE);
                    }
                }
                else
                {
                    Debug.Log("����ԁF�i�s�u���b�N�i�Q�[���I�[�o�[�ł͂Ȃ��j");
                    // �ʂ�Ȃ������Ȃ̂ŁA�������Ȃ���OK
                }
            }
        }
    }
}
