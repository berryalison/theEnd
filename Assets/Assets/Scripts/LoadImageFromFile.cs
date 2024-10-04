using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class LoadImageFromFile : MonoBehaviour
{
    public Image targetImage;               // 要设置图片的 Image 组件
    public string imagePath = @"E:\Files\Unity Assets\OOD\screenshot\Screenshot_1.png";  // 本地图片路径
    public float fadeDuration = 2f;         // 图片渐显的持续时间
    private bool imageLoaded = false;       // 记录图片是否已加载

    void Update()
    {
        // 判断父物体是否是 active，并且图片尚未加载
        if (targetImage != null && targetImage.transform.parent.gameObject.activeSelf && !imageLoaded)
        {
            StartCoroutine(LoadAndFadeInImage());  // 启动协程加载图片并渐显
            imageLoaded = true;  // 标记图片已加载
        }
    }

    // 协程：加载本地图片并渐显
    IEnumerator LoadAndFadeInImage()
    {
        // 加载本地图片
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);  // 创建一个新的 Texture2D
            texture.LoadImage(imageData);  // 将图片数据加载到纹理中

            // 将 Texture2D 转换为 Sprite 并设置为 Image 的 source
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            targetImage.sprite = newSprite;

            // 设置初始透明度
            CanvasGroup canvasGroup = targetImage.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = targetImage.gameObject.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f;  // 初始透明度为 0

            // 渐显图片
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = 1f;  // 最终透明度为 1
        }
        else
        {
            Debug.LogWarning("Image file not found at path: " + imagePath);
        }
    }
}

