using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer playerSprite;
    private PlayerController playerControllerScript;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerControllerScript = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerControllerScript.IsGrounded)
        {
            State = States.idle;
        }

        if (playerControllerScript.IsGrounded && Input.GetButton("Horizontal"))
        {
            State = States.run;
        }

        if (!playerControllerScript.IsGrounded)
        {
            State = States.jump;
        }
    }
}

public enum States
{
    idle,
    run,
    jump
}
