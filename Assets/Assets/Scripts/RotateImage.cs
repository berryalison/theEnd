using UnityEngine;
using UnityEngine.UI;

public class RotateImage : MonoBehaviour
{
    public Image targetImage;  // Ҫ��ת�� Image
    public float rotationTime = 180f;  // ��תһȦ��ʱ�䣨3���� = 180�룩

    private float rotationSpeed;

    void Start()
    {
        // ������ת�ٶȣ�ÿ��ĽǶȱ仯��
        rotationSpeed = 360f / rotationTime;  // ÿ����ת�ĽǶ�
    }

    void Update()
    {
        // �� Image ��ÿ�� rotationSpeed �Ƕ���������ת
        targetImage.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
