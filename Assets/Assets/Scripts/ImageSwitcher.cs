using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // ���볡������
using System.Collections;

public class ImageSwitcher : MonoBehaviour
{
    public Image imageDisplay;           // ��ʾͼƬ�� Image ���
    public Sprite[] images;              // �洢����ͼƬ������
    public float fadeDuration = 1.0f;    // �������Եĳ���ʱ��
    private int currentIndex = 0;        // ��ǰ��ʾ��ͼƬ����
    private CanvasGroup canvasGroup;     // CanvasGroup ��������ڿ���͸����
    private int spacePressCount = 0;     // ��¼�ո�����µĴ���

    void Start()
    {
        // ��ȡ CanvasGroup ���
        canvasGroup = imageDisplay.GetComponent<CanvasGroup>();

        // ��ʼ����ʾ��һ��ͼƬ
        if (images.Length > 0)
        {
            imageDisplay.sprite = images[currentIndex];
            canvasGroup.alpha = 1f;  // ȷ��ͼƬ����ȫ�ɼ���
        }
    }

    void Update()
    {
        // �����ո�����л�����һ��ͼƬ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressCount++;  // ��¼�ո�����´���

            if (spacePressCount >= 3)  // �����ΰ��ո�
            {
                SceneManager.LoadScene("GameScene");  // ��ת��GameScene
            }
            else
            {
                StartCoroutine(FadeToNextImage());  // �л�ͼƬ
            }
        }
    }

    // Э�̣�������ǰͼƬ��������һ��ͼƬ
    IEnumerator FadeToNextImage()
    {
        // ������ǰͼƬ
        yield return StartCoroutine(FadeOut());

        // �л�����һ��ͼƬ
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;  // ��ʾ��һ��ͼƬ
        }
        else
        {
            currentIndex = 0;  // ѭ������һ��
        }
        imageDisplay.sprite = images[currentIndex];

        // ������ͼƬ
        yield return StartCoroutine(FadeIn());
    }

    // Э�̣�����ͼƬ
    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }

    // Э�̣�����ͼƬ
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}

