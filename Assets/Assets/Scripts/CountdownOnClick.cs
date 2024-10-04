using UnityEngine;
using UnityEngine.UI;

public class CountdownOnClick : MonoBehaviour
{
    public Text countdownText;  // ��ʾ����ʱ�� Text ���
    private int clickCount = 0;  // ��¼�������
    private int countdown = 10;  // ����ʱ��ʼֵΪ10

    void Start()
    {
        // ��ʼ����ʾ����ʱ
        countdownText.text = countdown.ToString();
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
                clickCount = 0;  // ���õ������
                countdown--;     // ����ʱ���ּ�һ

                // ������ʾ�ĵ���ʱ
                countdownText.text = countdown.ToString();

                // ��ֹ����ʱ���� 0
                if (countdown <= 0)
                {
                    countdown = 0;
                }
            }
        }
    }
}