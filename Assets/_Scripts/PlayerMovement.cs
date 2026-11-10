/*using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    Rigidbody rb;
    Vector2 moveInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() // Rigidbd처럼 물리 법칙을 계산 할 때 씀
    {
        rb.MovePosition(rb.position + moveSpeed * transform.forward * moveInput.y * Time.fixedDeltaTime);

        float angle = moveInput.x * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, angle, 0));
    }

    void Update() //일반적인 입력이나 루프
    {
        moveInput.y = 0;
        moveInput.x = 0;
        Keyboard keyboard = Keyboard.current;
        if (keyboard.wKey.isPressed == true)
        {
            moveInput.y = 1;

        }

        if (keyboard.aKey.isPressed == true)
        {
            moveInput.x = -1;
        }


        if (keyboard.sKey.isPressed == true)
        {
            moveInput.y = -1;
        }


        if (keyboard.dKey.isPressed == true)
        {
            moveInput.x = 1;
        }
    }
}*/

using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.Unicode;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 60f;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference vertical;
    [SerializeField] private InputActionReference horizontal;
    [SerializeField] private InputActionReference lshift;

    private float moveInput;
    public float MoveInput
    {
        get
        {
            return moveInput;
        }
        set
        {
            if (MoveInput >= 0) value = moveInput;

        }
    }
    private float rotateInput;
    Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        vertical.action.Enable();
        horizontal.action.Enable();

        vertical.action.performed += Move;
        vertical.action.canceled += Move;

        horizontal.action.performed += Rotate;
        horizontal.action.canceled += Rotate;

        lshift.action.performed += Run;
        lshift.action.canceled += Run;
    }

    private void OnDisable()
    {
        vertical.action.performed -= Move;
        vertical.action.canceled -= Move;

        horizontal.action.performed -= Rotate;
        horizontal.action.canceled -= Rotate;

        lshift.action.performed -= Run;
        lshift.action.canceled -= Run;

        vertical.action.Disable();
        horizontal.action.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    private void Rotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<float>();
    }
    private void Run(InputAction.CallbackContext context)
    {
        if (context.performed) moveSpeed = 10f;
        else moveSpeed = 5f;

    }
    private void Update()
    {
        transform.Translate(
            Vector3.forward * moveInput * moveSpeed * Time.deltaTime
        );

        transform.Rotate(
            Vector3.up * rotateInput * turnSpeed * Time.deltaTime
        );
    }
}

