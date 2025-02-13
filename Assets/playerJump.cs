using UnityEngine;

public class playerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
        }
    }
}
