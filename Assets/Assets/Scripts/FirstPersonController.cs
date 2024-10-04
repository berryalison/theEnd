using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 10.0f;  // ����ƶ��ٶ�
    public float lookSpeed = 2.0f;  // ����ӽ���ת������
    public float jumpSpeed = 5.0f;  // ��Ծ�ٶ�
    public float gravity = 15f;    // ����

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;  // ���ز��������ָ��
    }

    void Update()
    {

        // �����ӽǵ���ת (�������)
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        float rotationY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.localRotation = Quaternion.Euler(0, rotationX, 0);  // ˮƽ��ת
        Camera.main.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);  // ��ֱ��ת



        // ��������ƶ�
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            // ��Ծ
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Ӧ������
        moveDirection.y -= gravity * Time.deltaTime;

        // �ƶ����
        controller.Move(moveDirection * Time.deltaTime);
    }
}
