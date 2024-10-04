using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSwitcher : MonoBehaviour
{
    public Image imageDisplay;           // 显示图片的 Image 组件
    public Sprite[] images;              // 存储所有图片的数组
    public float fadeDuration = 1.0f;    // 渐隐渐显的持续时间
    public float switchInterval = 60f;  // 切换图片的时间间隔（60秒）

    private int currentIndex = 0;        // 当前显示的图片索引
    private CanvasGroup canvasGroup;     // CanvasGroup 组件，用于控制透明度

    void Start()
    {
        // 获取 CanvasGroup 组件
        canvasGroup = imageDisplay.GetComponent<CanvasGroup>();

        // 初始化显示第一张图片
        if (images.Length > 0)
        {
            imageDisplay.sprite = images[currentIndex];
            canvasGroup.alpha = 1f;  // 确保图片是完全可见的
        }

        // 启动自动切换协程
        StartCoroutine(AutoSwitchImages());
    }

    // 协程：每隔指定的时间自动切换图片
    IEnumerator AutoSwitchImages()
    {
        while (true)  // 无限循环
        {
            // 等待指定的切换间隔
            yield return new WaitForSeconds(switchInterval);

            // 切换到下一张图片
            StartCoroutine(FadeToNextImage());
        }
    }

    // 协程：渐隐当前图片，渐显下一张图片
    IEnumerator FadeToNextImage()
    {
        // 渐隐当前图片
        yield return StartCoroutine(FadeOut());

        // 切换到下一张图片
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;  // 显示下一张图片
        }
        else
        {
            currentIndex = 0;  // 循环到第一张
        }
        imageDisplay.sprite = images[currentIndex];

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
