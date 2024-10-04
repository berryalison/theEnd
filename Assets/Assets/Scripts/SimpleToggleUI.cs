using UnityEngine;

public class SimpleToggleUI : MonoBehaviour
{
    // 要显示或隐藏的 UI 对象
    public GameObject uiElement;

    // 切换 UI 显示/隐藏
    public void ToggleUI()
    {
        if (uiElement != null)
        {
            bool isActive = uiElement.activeSelf;
            uiElement.SetActive(!isActive);  // 切换显示/隐藏状态
        }
    }
}

