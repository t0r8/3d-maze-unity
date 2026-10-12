using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private bool rollObject = false;
    [SerializeField] private Transform visualObject;
    [SerializeField] private Vector3 rollAxis = Vector3.right;
    [SerializeField] private float rollSpeed = 180.0f;

    private Rigidbody rb;

    private bool movingToB = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 targetPosition;

        if (movingToB)
        {
            targetPosition = pointB.position;
        }
        else
        {
            targetPosition = pointA.position;
        }

        Vector3 nextPosition = Vector3.MoveTowards(
            rb.position,
            targetPosition,
            moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(nextPosition);

        if (rollObject && visualObject != null)
        {
            float rollDirection;

            if (movingToB)
            {
                rollDirection = 1.0f;
            }
            else
            {
                rollDirection = -1.0f;
            }

            visualObject.Rotate(
                rollAxis,
                rollSpeed * rollDirection * Time.fixedDeltaTime,
                Space.Self
            );
        }

        if (Vector3.Distance(nextPosition, targetPosition) < 0.01f)
        {
            movingToB = !movingToB;
        }
    }
}