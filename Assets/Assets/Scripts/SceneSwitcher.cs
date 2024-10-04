using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // 引入 UI 命名空间

public class SceneSwitcher : MonoBehaviour
{
    public Button switchButton;   // 在 Inspector 中指定的按钮
    public string sceneName;      // 在 Inspector 中指定要切换的场景名称

    void Start()
    {
        // 添加按钮点击事件监听
        switchButton.onClick.AddListener(SwitchScene);
    }

    // 切换场景的函数
    public void SwitchScene()
    {
        if (!string.IsNullOrEmpty(sceneName))  // 确保场景名称不为空
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set or is empty!");
        }
    }
}


