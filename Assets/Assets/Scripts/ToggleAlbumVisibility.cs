using UnityEngine;

public class ToggleAlbumVisibility : MonoBehaviour
{
    // 要显示或隐藏的相册 UI 对象
    public GameObject albumUI;

    // 检测按键输入，按 T 键切换相册 UI 的显示或隐藏状态
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (albumUI != null)
            {
                // 切换相册 UI 的显示或隐藏状态
                bool isActive = albumUI.activeSelf;
                albumUI.SetActive(!isActive);
            }
        }
    }
}
