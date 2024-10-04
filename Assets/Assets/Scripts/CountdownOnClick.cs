using UnityEngine;
using UnityEngine.UI;

public class CountdownOnClick : MonoBehaviour
{
    public Text countdownText;  // 显示倒计时的 Text 组件
    private int clickCount = 0;  // 记录点击次数
    private int countdown = 10;  // 倒计时初始值为10

    void Start()
    {
        // 初始化显示倒计时
        countdownText.text = countdown.ToString();
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
                clickCount = 0;  // 重置点击计数
                countdown--;     // 倒计时数字减一

                // 更新显示的倒计时
                countdownText.text = countdown.ToString();

                // 防止倒计时低于 0
                if (countdown <= 0)
                {
                    countdown = 0;
                }
            }
        }
    }
}