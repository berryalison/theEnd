using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadImageAndFadeIn : MonoBehaviour
{
    public Image targetImage; // Ŀ��Image���
    public GameObject parentObject; // �����壬������Inspector������
    public string imagePath = @"E:\Files\Unity Assets\OOD\screenshot\Screenshot_1.png"; // ����ͼƬ·��
    public float fadeDuration = 2f; // ���Գ���ʱ��

    private void Update()
    {
        // ��鸸�����Ƿ�Ϊactive������Ŀ��Image����active״̬
        if (targetImage.gameObject.activeInHierarchy && parentObject.activeInHierarchy)
        {
            StartCoroutine(LoadImageAndFadeInCoroutine());
        }
    }

    IEnumerator LoadImageAndFadeInCoroutine()
    {
        // ���ر���ͼƬ
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            // ��ͼƬת��ΪSprite
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            targetImage.sprite = newSprite;

            // ����
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
