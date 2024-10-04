using UnityEngine;

public class ToggleAlbumVisibility : MonoBehaviour
{
    // Ҫ��ʾ�����ص���� UI ����
    public GameObject albumUI;

    // ��ⰴ�����룬�� T ���л���� UI ����ʾ������״̬
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (albumUI != null)
            {
                // �л���� UI ����ʾ������״̬
                bool isActive = albumUI.activeSelf;
                albumUI.SetActive(!isActive);
            }
        }
    }
}
