using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSwitcher : MonoBehaviour
{
    public Image imageDisplay;           // ��ʾͼƬ�� Image ���
    public Sprite[] images;              // �洢����ͼƬ������
    public float fadeDuration = 1.0f;    // �������Եĳ���ʱ��
    public float switchInterval = 60f;  // �л�ͼƬ��ʱ������60�룩

    private int currentIndex = 0;        // ��ǰ��ʾ��ͼƬ����
    private CanvasGroup canvasGroup;     // CanvasGroup ��������ڿ���͸����

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

        // �����Զ��л�Э��
        StartCoroutine(AutoSwitchImages());
    }

    // Э�̣�ÿ��ָ����ʱ���Զ��л�ͼƬ
    IEnumerator AutoSwitchImages()
    {
        while (true)  // ����ѭ��
        {
            // �ȴ�ָ�����л����
            yield return new WaitForSeconds(switchInterval);

            // �л�����һ��ͼƬ
            StartCoroutine(FadeToNextImage());
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
