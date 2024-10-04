using UnityEngine;

public class TogglePanelVisibility : MonoBehaviour
{
    // ��Ҫ��ʾ�����ص� Panel
    public GameObject panel;

    void Start()
    {
        // ��� Panel �Ƿ��Ѹ�ֵ
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned!");
        }
    }

    void Update()
    {
        // ��������Ҽ� (1 ��ʾ�Ҽ�)
        if (Input.GetMouseButtonDown(1))
        {
            // ��� Panel ���ڣ����л�������ʾ״̬
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);
            }
        }
    }
}
