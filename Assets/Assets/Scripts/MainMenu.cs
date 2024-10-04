using UnityEngine;
using TMPro;

public class DecreaseNumberOnClick : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;  // TextMeshPro组件
    private int clickCount = 0;          // 记录点击次数
    private int number = 10;             // 初始数字

    void Start()
    {
        // 初始化文本内容
        textDisplay.text = number.ToString();
    }

    void Update()
    {
        // 检测左键点击
        if (Input.GetMouseButtonDown(0))  // 0 表示左键
        {
            clickCount++;

            // 每两次点击触发一次
            if (clickCount >= 2)
            {
                clickCount = 0;  // 重置计数器
                number--;  // 数字减一

                // 更新 TextMeshPro 显示
                textDisplay.text = number.ToString();
            }
        }
    }
}
