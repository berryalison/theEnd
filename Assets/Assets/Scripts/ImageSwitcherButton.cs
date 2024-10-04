using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcherButton : MonoBehaviour
{
    public Image targetImage;           // 显示图片的 Image 组件
    public Sprite[] images;             // 存储所有图片的数组
    public Button switchButton;         // 用来切换图片的按钮
    private int currentIndex = 0;       // 当前显示的图片索引

    void Start()
    {
        // 确保按钮绑定了点击事件
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(OnButtonClick);
        }

        // 初始化显示第一张图片
        if (images.Length > 0)
        {
            targetImage.sprite = images[currentIndex];
        }
    }

    // 按下按钮时调用的函数
    public void OnButtonClick()
    {
        // 切换到下一张图片
        if (images.Length > 0)
        {
            currentIndex++;  // 递增索引
            if (currentIndex >= images.Length)  // 超出范围则回到第一张
            {
                currentIndex = 0;
            }

            // 切换图片
            targetImage.sprite = images[currentIndex];
        }
    }
}
