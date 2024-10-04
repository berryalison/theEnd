using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // ���� UI �����ռ�

public class SceneSwitcher : MonoBehaviour
{
    public Button switchButton;   // �� Inspector ��ָ���İ�ť
    public string sceneName;      // �� Inspector ��ָ��Ҫ�л��ĳ�������

    void Start()
    {
        // ��Ӱ�ť����¼�����
        switchButton.onClick.AddListener(SwitchScene);
    }

    // �л������ĺ���
    public void SwitchScene()
    {
        if (!string.IsNullOrEmpty(sceneName))  // ȷ���������Ʋ�Ϊ��
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set or is empty!");
        }
    }
}


