using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Animation")]
    public Animator animatorPlayer;


    private Vector2 input;
    private bool moving;

    public float walkSpeed = 3.0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void UpdateAnimation()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving && Resources1.isInvert == false)
        {
            animatorPlayer.SetFloat("x", input.x);
            animatorPlayer.SetFloat("y", input.y);
        }
        else if (moving && Resources1.isInvert == true)
        {
            animatorPlayer.SetFloat("x", -input.x);
            animatorPlayer.SetFloat("y", -input.y);
        }

        animatorPlayer.SetBool("moving", moving);
    }

    void Update()
    {
        Vector2 move = new Vector2(0,0);


        if (Resources1.isInvert == false)
        {
            Debug.Log("Falso");
            move = new Vector2(input.x, input.y);
        }
        else if (Resources1.isInvert == true)
        {
            Debug.Log("True");
            move = new Vector2(-input.x, -input.y);
        }
        transform.Translate(move * walkSpeed * Time.deltaTime, Space.World);


        UpdateAnimation();
    }

    public void GetInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

}
