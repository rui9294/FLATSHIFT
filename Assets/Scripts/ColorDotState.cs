using UnityEngine;

public class ColorDotState : MonoBehaviour
{
    public enum DotType { Gray, Red, Blue }  // �K�v�ɉ����Ēǉ�
    public DotType dotType;

    public void DisappearIfMatch(DotType waveType)
    {
        if (dotType == waveType)
        {
            gameObject.SetActive(false); // ���� or �A�j���[�V����
        }
    }
}
