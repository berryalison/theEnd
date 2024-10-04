using UnityEngine;
using TMPro;

public class DecreaseNumberOnClick : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;  // TextMeshPro���
    private int clickCount = 0;          // ��¼�������
    private int number = 10;             // ��ʼ����

    void Start()
    {
        // ��ʼ���ı�����
        textDisplay.text = number.ToString();
    }

    void Update()
    {
        // ���������
        if (Input.GetMouseButtonDown(0))  // 0 ��ʾ���
        {
            clickCount++;

            // ÿ���ε������һ��
            if (clickCount >= 2)
            {
                clickCount = 0;  // ���ü�����
                number--;  // ���ּ�һ

                // ���� TextMeshPro ��ʾ
                textDisplay.text = number.ToString();
            }
        }
    }
}
