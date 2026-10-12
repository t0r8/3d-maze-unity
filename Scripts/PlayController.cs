using UnityEngine;
using UnityEngine.InputSystem;

public class PlayController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 100.0f;
    public float jumpForce = 5.0f;

    public InputAction moveAction;
    public InputAction jumpAction;

    private Vector2 moveInput;
    private Rigidbody rb;
    private bool isGrounded = true;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        jumpAction.Enable();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x);

        bool isMoving = Mathf.Abs(moveInput.y) > 0.01f;
        playerAnimator.SetBool("IsMoving", isMoving);

         if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpSound);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}