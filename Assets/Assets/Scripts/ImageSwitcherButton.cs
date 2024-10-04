using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcherButton : MonoBehaviour
{
    public Image targetImage;           // ��ʾͼƬ�� Image ���
    public Sprite[] images;             // �洢����ͼƬ������
    public Button switchButton;         // �����л�ͼƬ�İ�ť
    private int currentIndex = 0;       // ��ǰ��ʾ��ͼƬ����

    void Start()
    {
        // ȷ����ť���˵���¼�
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(OnButtonClick);
        }

        // ��ʼ����ʾ��һ��ͼƬ
        if (images.Length > 0)
        {
            targetImage.sprite = images[currentIndex];
        }
    }

    // ���°�ťʱ���õĺ���
    public void OnButtonClick()
    {
        // �л�����һ��ͼƬ
        if (images.Length > 0)
        {
            currentIndex++;  // ��������
            if (currentIndex >= images.Length)  // ������Χ��ص���һ��
            {
                currentIndex = 0;
            }

            // �л�ͼƬ
            targetImage.sprite = images[currentIndex];
        }
    }
}
