using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody rb;

    private PlayerInput playerInput;

    private Vector2 moveInput;

    private Animator animator;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    public bool isHolding;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = transform.TransformDirection(new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, moveInput.y * moveSpeed));
        Debug.Log(rb.linearVelocity.magnitude);
        if (rb.linearVelocity != Vector3.zero)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        if (moveInput == Vector2.zero)
        {
            rb.linearVelocity = Vector3.zero;
        }
        //Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        //rb.AddForce(move * moveSpeed * Time.deltaTime * 100, ForceMode.Force);
    }

    private void Update()
    {
        
    }
}
