using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public GameObject creditPanel;     // Credit 面板
    public GameObject mainMenuPanel;   // 主菜单面板

    // 显示 Credit 面板并隐藏主菜单
    public void ShowCredit()
    {
        creditPanel.SetActive(true);   // 显示 Credit 界面
        mainMenuPanel.SetActive(false); // 隐藏主菜单界面
    }

    // 隐藏 Credit 面板并显示主菜单
    public void HideCredit()
    {
        creditPanel.SetActive(false);  // 隐藏 Credit 界面
        mainMenuPanel.SetActive(true); // 显示主菜单界面
    }
}
