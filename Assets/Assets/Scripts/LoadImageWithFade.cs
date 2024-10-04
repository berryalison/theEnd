using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadImageAndFadeIn : MonoBehaviour
{
    public Image targetImage; // 目标Image组件
    public GameObject parentObject; // 父物体，可以在Inspector中设置
    public string imagePath = @"E:\Files\Unity Assets\OOD\screenshot\Screenshot_1.png"; // 本地图片路径
    public float fadeDuration = 2f; // 渐显持续时间

    private void Update()
    {
        // 检查父物体是否为active，并且目标Image处于active状态
        if (targetImage.gameObject.activeInHierarchy && parentObject.activeInHierarchy)
        {
            StartCoroutine(LoadImageAndFadeInCoroutine());
        }
    }

    IEnumerator LoadImageAndFadeInCoroutine()
    {
        // 加载本地图片
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            // 将图片转换为Sprite
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            targetImage.sprite = newSprite;

            // 渐显
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0f);
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
                targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, alpha);
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Image not found at path: " + imagePath);
        }
    }
}
