using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    // 相关 UI 和对象
    public GameObject targetObject;  // 指定的物体
    public GameObject dialogueUI;    // 显示的对话 UI
    public Button dialogueButton;    // 开启对话的按钮
    public Image imageDisplay;       // 用于显示对话图片
    public Sprite[] images;          // 对话中使用的图片序列
    public float fadeDuration = 1f;  // 图片渐隐渐显的持续时间
    public CanvasGroup canvasGroup;  // 图片渐隐渐显的 CanvasGroup

    private int currentIndex = 0;    // 当前图片索引
    private bool isDialogueStarted = false;  // 对话是否已经开始

    void Start()
    {
        dialogueUI.SetActive(false);  // 初始隐藏对话UI
        dialogueButton.onClick.AddListener(StartDialogue);  // 为按钮添加点击事件
    }

    void Update()
    {
        // 检查目标对象是否已被激活
        if (targetObject.activeSelf && !isDialogueStarted)
        {
            StartCoroutine(ShowDialogueUIAfterDelay(10f));  // 10秒后显示对话UI
            isDialogueStarted = true;
        }

        // 监听空格键进行对话切换
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueStarted)
        {
            // 仅当未到达最后一张图片时才进行切换
            if (currentIndex < images.Length - 1)
            {
                StartCoroutine(FadeToNextImage());
            }
        }
    }

    // 协程：延时10秒显示对话UI
    IEnumerator ShowDialogueUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueUI.SetActive(true);  // 显示对话UI
    }

    // 开始对话的函数
    void StartDialogue()
    {
        if (!isDialogueStarted)
        {
            isDialogueStarted = true;
            currentIndex = 0;  // 初始化图片索引
            imageDisplay.sprite = images[currentIndex];  // 显示第一张图片
            StartCoroutine(FadeIn());  // 渐显第一张图片
        }
    }

    // 协程：渐隐当前图片，渐显下一张图片
    IEnumerator FadeToNextImage()
    {
        // 渐隐当前图片
        yield return StartCoroutine(FadeOut());

        // 切换到下一张图片
        currentIndex++;  // 递增索引
        if (currentIndex < images.Length)
        {
            // 更新显示的图片
            imageDisplay.sprite = images[currentIndex];
        }

        // 渐显新图片
        yield return StartCoroutine(FadeIn());
    }

    // 协程：渐隐图片
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

    // 协程：渐显图片
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

