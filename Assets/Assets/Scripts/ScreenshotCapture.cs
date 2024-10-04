using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScreenshotCapture : MonoBehaviour
{
    // ���ý�ͼ�����
    private int screenshotIndex = 1;

    // �Զ��屣��·��
    private string customPath = @"E:\Files\Unity Assets\OOD\screenshot";

    // UI ���
    public GameObject photoUI;          // ���� UI ������͸���� Image��
    public RectTransform screenshotArea; // ͸�� Image�����ڱ�ʾ��ͼ����
    private bool isPhotoMode = false;   // ��ǰ�Ƿ�������ģʽ

    // Animator ���
    public Animator cameraAnimator;

    // ghost���
    public GameObject hiddenObject;  // ��Ҫ��ʾ�����ض���

    // Panel ���
    public GameObject panelUI;        // �������� UI �� Panel
    public GameObject blurImage;      // ������ʾ blur Ч���� Image

    // ��ͼ�õ������
    public Camera cameraShot;

    // �������ڶ��ε���ж�
    private bool firstClick = false;

    void Update()
    {
        // ���� Q ������ʾ���������� UI
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPhotoMode = !isPhotoMode;
            photoUI.SetActive(isPhotoMode); // �������� UI ����ʾ������
        }

        // ���������������н�ͼ����ʾ���󲢲��Ŷ���
        if (isPhotoMode && Input.GetMouseButtonDown(0))  // 0 ��ʾ������
        {
            if (!firstClick) // ��һ�ε��
            {
                // ��ʾ����Ͳ��Ŷ���
                cameraAnimator.SetTrigger("Shoot");
                hiddenObject.SetActive(true);

                // ����Э�̣���ʱ0.1���ͼ
                StartCoroutine(TakeScreenshotWithDelay(0.1f));

                // ��ǵ�һ�ε��
                firstClick = true;
            }
            else // �ڶ��ε��
            {
                blurImage.SetActive(false);     // ���صڶ�������
            }
        }
    }

    // Э�̣���ʱ0.1�����н�ͼ������2.5�������Panel����ʾblurЧ��
    IEnumerator TakeScreenshotWithDelay(float delay)
    {
        // �ȴ�0.1��
        yield return new WaitForSeconds(delay);

        // ִ�н�ͼ�߼�
        TakeScreenshot();

        // �ȴ�2.5�������Panel������ʾblur��Image
        yield return new WaitForSeconds(2.5f);
        panelUI.SetActive(false);  // ���ذ�������UI��Panel
        blurImage.SetActive(true); // ��ʾblur Image
    }

    // ��ͼ����
    public void TakeScreenshot()
    {
        // ����Զ���·���Ƿ���ڣ�����������򴴽�
        if (!Directory.Exists(customPath))
        {
            Directory.CreateDirectory(customPath);
        }

        // ��ȡ��ͼ�������Ļ����
        Vector3[] corners = new Vector3[4];
        screenshotArea.GetWorldCorners(corners);

        // �����ͼ��������ط�Χ
        Rect rect = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        // ����һ�� RenderTexture ����ȡ������
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 24);
        cameraShot.targetTexture = rt;  // �� Camera-shot ��Ŀ������Ϊ RenderTexture
        cameraShot.Render();            // ��Ⱦ����������ݵ� RenderTexture

        // ������ͼ������
        RenderTexture.active = rt;
        Texture2D screenshot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);  // �� RenderTexture ��ȡ����
        screenshot.Apply();

        // �����ͼ���ļ�
        string fileName = "Screenshot_" + screenshotIndex.ToString() + ".png";
        string filePath = Path.Combine(customPath, fileName);
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);

        // �����ͼ����·��������̨
        Debug.Log("Screenshot saved to: " + filePath);

        // ������Դ
        cameraShot.targetTexture = null;  // ������ RenderTexture ֮ǰ���Ƚ� targetTexture ��Ϊ null
        RenderTexture.active = null;      // ȷ��û��ʹ�õ� RenderTexture ���ڼ���״̬
        rt.Release();                     // �ͷ� RenderTexture
        Destroy(rt);                      // ���� RenderTexture

        // ÿ�ν�ͼ���������
        screenshotIndex++;
    }


}
