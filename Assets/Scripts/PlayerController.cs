using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Animation")]
    public Animator animatorPlayer;

    public float walkSpeed = 3.0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        
        rb.linearVelocity = new Vector2(movX * walkSpeed, movY * walkSpeed);

        UpdateAnimation(movX, movY);
    }

    void UpdateAnimation(float movX, float movY)
    {
        bool walkRight = movX > 0;
        bool walkLeft = movX < 0;
        bool walkUp = movY > 0;
        bool walkDown = movY < 0;

        animatorPlayer.SetBool("WalkRight", walkRight);
        animatorPlayer.SetBool("WalkLeft", walkLeft);
        animatorPlayer.SetBool("WalkUp", walkUp);
        animatorPlayer.SetBool("WalkDown", walkDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
