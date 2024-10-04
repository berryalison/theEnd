using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcherOnSpace : MonoBehaviour
{
    public Image imageDisplay;           // 显示图片的 Image 组件
    public Sprite[] images;              // 存储所有图片的数组
    public float fadeDuration = 1.0f;    // 渐隐渐显的持续时间
    private int currentIndex = 0;        // 当前显示的图片索引

    private CanvasGroup canvasGroup;     // CanvasGroup 组件用于控制透明度

    void Start()
    {
        // 获取 CanvasGroup 组件
        canvasGroup = imageDisplay.GetComponent<CanvasGroup>();

        // 初始化显示第一张图片
        if (images.Length > 0)
        {
            imageDisplay.sprite = images[currentIndex];
            canvasGroup.alpha = 1f;  // 确保图片一开始是完全可见的
        }
    }

    void Update()
    {
        // 监听空格键，切换到下一张图片
        if (Input.GetKeyDown(KeyCode.Space))  // Space 表示空格键
        {
            // 仅当未到达最后一张图片时才进行切换
            if (currentIndex < images.Length - 1)
            {
                StartCoroutine(FadeToNextImage());
            }
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

