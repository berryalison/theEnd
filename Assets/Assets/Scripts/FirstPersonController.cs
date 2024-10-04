using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 10.0f;  // 玩家移动速度
    public float lookSpeed = 2.0f;  // 鼠标视角旋转灵敏度
    public float jumpSpeed = 5.0f;  // 跳跃速度
    public float gravity = 15f;    // 重力

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;  // 隐藏并锁定鼠标指针
    }

    void Update()
    {

        // 控制视角的旋转 (鼠标输入)
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        float rotationY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.localRotation = Quaternion.Euler(0, rotationX, 0);  // 水平旋转
        Camera.main.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);  // 垂直旋转



        // 控制玩家移动
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            // 跳跃
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // 应用重力
        moveDirection.y -= gravity * Time.deltaTime;

        // 移动玩家
        controller.Move(moveDirection * Time.deltaTime);
    }
}
