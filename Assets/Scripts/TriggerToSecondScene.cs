using UnityEngine;
using UnityEngine.SceneManagement;

public class GrayCircleTriggerToSecondScene : MonoBehaviour
{
    public float delayBeforeSecondScene = 2f;  // ���b�҂��Ă���V�[����؂�ւ��邩
    public string nextSceneName = "SecondScene";  // �J�ڐ�̃V�[����

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("�v���C���[���D�ۂɐڐG�I�V�[���J�ڂ̏������c");
            Invoke("LoadSecondScene", delayBeforeSecondScene);
        }
    }

    private void LoadSecondScene()
    {
        Debug.Log("���̃V�[���ֈړ��I");
        SceneManager.LoadScene("SecondScene");
    }
}
