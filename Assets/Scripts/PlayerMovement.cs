using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    [SerializeField]
    private int speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 move = transform.right * x + transform.up * y;
        moveVelocity = move.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
