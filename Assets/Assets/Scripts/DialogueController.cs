using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    // ��� UI �Ͷ���
    public GameObject targetObject;  // ָ��������
    public GameObject dialogueUI;    // ��ʾ�ĶԻ� UI
    public Button dialogueButton;    // �����Ի��İ�ť
    public Image imageDisplay;       // ������ʾ�Ի�ͼƬ
    public Sprite[] images;          // �Ի���ʹ�õ�ͼƬ����
    public float fadeDuration = 1f;  // ͼƬ�������Եĳ���ʱ��
    public CanvasGroup canvasGroup;  // ͼƬ�������Ե� CanvasGroup

    private int currentIndex = 0;    // ��ǰͼƬ����
    private bool isDialogueStarted = false;  // �Ի��Ƿ��Ѿ���ʼ

    void Start()
    {
        dialogueUI.SetActive(false);  // ��ʼ���ضԻ�UI
        dialogueButton.onClick.AddListener(StartDialogue);  // Ϊ��ť��ӵ���¼�
    }

    void Update()
    {
        // ���Ŀ������Ƿ��ѱ�����
        if (targetObject.activeSelf && !isDialogueStarted)
        {
            StartCoroutine(ShowDialogueUIAfterDelay(10f));  // 10�����ʾ�Ի�UI
            isDialogueStarted = true;
        }

        // �����ո�����жԻ��л�
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueStarted)
        {
            // ����δ�������һ��ͼƬʱ�Ž����л�
            if (currentIndex < images.Length - 1)
            {
                StartCoroutine(FadeToNextImage());
            }
        }
    }

    // Э�̣���ʱ10����ʾ�Ի�UI
    IEnumerator ShowDialogueUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueUI.SetActive(true);  // ��ʾ�Ի�UI
    }

    // ��ʼ�Ի��ĺ���
    void StartDialogue()
    {
        if (!isDialogueStarted)
        {
            isDialogueStarted = true;
            currentIndex = 0;  // ��ʼ��ͼƬ����
            imageDisplay.sprite = images[currentIndex];  // ��ʾ��һ��ͼƬ
            StartCoroutine(FadeIn());  // ���Ե�һ��ͼƬ
        }
    }

    // Э�̣�������ǰͼƬ��������һ��ͼƬ
    IEnumerator FadeToNextImage()
    {
        // ������ǰͼƬ
        yield return StartCoroutine(FadeOut());

        // �л�����һ��ͼƬ
        currentIndex++;  // ��������
        if (currentIndex < images.Length)
        {
            // ������ʾ��ͼƬ
            imageDisplay.sprite = images[currentIndex];
        }

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

