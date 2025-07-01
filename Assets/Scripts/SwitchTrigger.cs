using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject grayWaveObject;  // �A�N�e�B�u���E��������g��I�u�W�F�N�g
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // �g��̈ʒu���X�C�b�`�ɍ��킹��
            grayWaveObject.transform.position = transform.position;

            // �X�P�[����������
            grayWaveObject.transform.localScale = Vector3.one;

            // �A�N�e�B�u�ɂ��Ă���g��𔭓�
            grayWaveObject.SetActive(true);
            grayWaveObject.GetComponent<ColorWaveEffect>().StartWave();
        }
    }
}
