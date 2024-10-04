using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class LoadImageFromFile : MonoBehaviour
{
    public Image targetImage;               // Ҫ����ͼƬ�� Image ���
    public string imagePath = @"E:\Files\Unity Assets\OOD\screenshot\Screenshot_1.png";  // ����ͼƬ·��
    public float fadeDuration = 2f;         // ͼƬ���Եĳ���ʱ��
    private bool imageLoaded = false;       // ��¼ͼƬ�Ƿ��Ѽ���

    void Update()
    {
        // �жϸ������Ƿ��� active������ͼƬ��δ����
        if (targetImage != null && targetImage.transform.parent.gameObject.activeSelf && !imageLoaded)
        {
            StartCoroutine(LoadAndFadeInImage());  // ����Э�̼���ͼƬ������
            imageLoaded = true;  // ���ͼƬ�Ѽ���
        }
    }

    // Э�̣����ر���ͼƬ������
    IEnumerator LoadAndFadeInImage()
    {
        // ���ر���ͼƬ
        if (File.Exists(imagePath))
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);  // ����һ���µ� Texture2D
            texture.LoadImage(imageData);  // ��ͼƬ���ݼ��ص�������

            // �� Texture2D ת��Ϊ Sprite ������Ϊ Image �� source
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            targetImage.sprite = newSprite;

            // ���ó�ʼ͸����
            CanvasGroup canvasGroup = targetImage.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = targetImage.gameObject.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f;  // ��ʼ͸����Ϊ 0

            // ����ͼƬ
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = 1f;  // ����͸����Ϊ 1
        }
        else
        {
            Debug.LogWarning("Image file not found at path: " + imagePath);
        }
    }
}

