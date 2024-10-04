using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public GameObject creditPanel;     // Credit ���
    public GameObject mainMenuPanel;   // ���˵����

    // ��ʾ Credit ��岢�������˵�
    public void ShowCredit()
    {
        creditPanel.SetActive(true);   // ��ʾ Credit ����
        mainMenuPanel.SetActive(false); // �������˵�����
    }

    // ���� Credit ��岢��ʾ���˵�
    public void HideCredit()
    {
        creditPanel.SetActive(false);  // ���� Credit ����
        mainMenuPanel.SetActive(true); // ��ʾ���˵�����
    }
}
