using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 4;
    [SerializeField] private float runSpeed = 8;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] InputActionAsset inputActions;

    private Rigidbody2D rb;
    
    void OnEnable()=> inputActions.FindActionMap("Player").Enable();
    void OnDisable()=> inputActions.FindActionMap("Player").Disable();


    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    void Start()
    {
        moveAction = inputActions.FindAction("Move");
        sprintAction = inputActions.FindAction("Sprint");
        rb = transform.GetComponent<Rigidbody2D>();
        jumpAction = inputActions.FindAction("Jump");
    }

    [System.Obsolete]
void Update()
    {
        float moveX = moveAction.ReadValue<Vector2>().x;
        float speed = sprintAction.IsPressed() ? runSpeed : walkSpeed;

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (moveX != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);

        if (jumpAction.triggered)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}