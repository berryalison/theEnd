using UnityEngine;

public class TogglePanelVisibility : MonoBehaviour
{
    // 需要显示或隐藏的 Panel
    public GameObject panel;

    void Start()
    {
        // 检查 Panel 是否已赋值
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned!");
        }
    }

    void Update()
    {
        // 监听鼠标右键 (1 表示右键)
        if (Input.GetMouseButtonDown(1))
        {
            // 如果 Panel 存在，则切换它的显示状态
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);
            }
        }
    }
}
