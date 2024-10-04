using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    public Image targetImage;  // 要旋转的 Image
    public float rotationTime = 180f;  // 旋转一圈的时间（3分钟 = 180秒）

    private float rotationSpeed;

    void Start()
    {
        // 计算旋转速度（每秒的角度变化）
        rotationSpeed = 360f / rotationTime;  // 每秒旋转的角度
    }

    void Update()
    {
        // 让 Image 以每秒 rotationSpeed 角度绕中心旋转
        targetImage.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
