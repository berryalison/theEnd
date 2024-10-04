using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScreenshotCapture : MonoBehaviour
{
    // 设置截图的序号
    private int screenshotIndex = 1;

    // 自定义保存路径
    private string customPath = @"E:\Files\Unity Assets\OOD\screenshot";

    // UI 相关
    public GameObject photoUI;          // 拍照 UI （包含透明的 Image）
    public RectTransform screenshotArea; // 透明 Image，用于表示截图区域
    private bool isPhotoMode = false;   // 当前是否处于拍照模式

    // Animator 相关
    public Animator cameraAnimator;

    // ghost相关
    public GameObject hiddenObject;  // 需要显示的隐藏对象

    // Panel 相关
    public GameObject panelUI;        // 包含所有 UI 的 Panel
    public GameObject blurImage;      // 用于显示 blur 效果的 Image

    // 截图用的摄像机
    public Camera cameraShot;

    // 新增：第二次点击判断
    private bool firstClick = false;

    void Update()
    {
        // 监听 Q 键，显示或隐藏拍照 UI
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPhotoMode = !isPhotoMode;
            photoUI.SetActive(isPhotoMode); // 控制拍照 UI 的显示和隐藏
        }

        // 监听鼠标左键，进行截图，显示对象并播放动画
        if (isPhotoMode && Input.GetMouseButtonDown(0))  // 0 表示鼠标左键
        {
            if (!firstClick) // 第一次点击
            {
                // 显示物体和播放动画
                cameraAnimator.SetTrigger("Shoot");
                hiddenObject.SetActive(true);

                // 启动协程，延时0.1秒截图
                StartCoroutine(TakeScreenshotWithDelay(0.1f));

                // 标记第一次点击
                firstClick = true;
            }
            else // 第二次点击
            {
                blurImage.SetActive(false);     // 隐藏第二个物体
            }
        }
    }

    // 协程：延时0.1秒后进行截图，并在2.5秒后隐藏Panel和显示blur效果
    IEnumerator TakeScreenshotWithDelay(float delay)
    {
        // 等待0.1秒
        yield return new WaitForSeconds(delay);

        // 执行截图逻辑
        TakeScreenshot();

        // 等待2.5秒后隐藏Panel，并显示blur的Image
        yield return new WaitForSeconds(2.5f);
        panelUI.SetActive(false);  // 隐藏包含所有UI的Panel
        blurImage.SetActive(true); // 显示blur Image
    }

    // 截图函数
    public void TakeScreenshot()
    {
        // 检查自定义路径是否存在，如果不存在则创建
        if (!Directory.Exists(customPath))
        {
            Directory.CreateDirectory(customPath);
        }

        // 获取截图区域的屏幕坐标
        Vector3[] corners = new Vector3[4];
        screenshotArea.GetWorldCorners(corners);

        // 计算截图区域的像素范围
        Rect rect = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        // 创建一个 RenderTexture 并截取该区域
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 24);
        cameraShot.targetTexture = rt;  // 将 Camera-shot 的目标设置为 RenderTexture
        cameraShot.Render();            // 渲染摄像机的内容到 RenderTexture

        // 创建截图的纹理
        RenderTexture.active = rt;
        Texture2D screenshot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);  // 从 RenderTexture 读取像素
        screenshot.Apply();

        // 保存截图到文件
        string fileName = "Screenshot_" + screenshotIndex.ToString() + ".png";
        string filePath = Path.Combine(customPath, fileName);
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);

        // 输出截图保存路径到控制台
        Debug.Log("Screenshot saved to: " + filePath);

        // 清理资源
        cameraShot.targetTexture = null;  // 在销毁 RenderTexture 之前，先将 targetTexture 置为 null
        RenderTexture.active = null;      // 确保没有使用的 RenderTexture 处于激活状态
        rt.Release();                     // 释放 RenderTexture
        Destroy(rt);                      // 销毁 RenderTexture

        // 每次截图后，增加序号
        screenshotIndex++;
    }


}
