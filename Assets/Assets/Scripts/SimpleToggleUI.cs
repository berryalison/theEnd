using UnityEngine;

public class SimpleToggleUI : MonoBehaviour
{
    // Ҫ��ʾ�����ص� UI ����
    public GameObject uiElement;

    // �л� UI ��ʾ/����
    public void ToggleUI()
    {
        if (uiElement != null)
        {
            bool isActive = uiElement.activeSelf;
            uiElement.SetActive(!isActive);  // �л���ʾ/����״̬
        }
    }
}

