using UnityEngine;

public class playerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public float jump;
    public AudioClip jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing on the GameObject.");
                return;
            }
            if (jumpSound == null)
            {
                Debug.LogError("Jump sound clip is not assigned in the Inspector.");
                return;
            }
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
