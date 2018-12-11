using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private  float speed = 5f;
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float powerJump = 15f;

    private bool isGrounded = false;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGroung();
    }

    private void Update()
    {
        if (isGrounded) { State = State.Idle; }

        if (Input.GetButton("Horizontal")) { Move(); }
        if (Input.GetButton("Jump") && isGrounded) { Jump(); }

	}


    protected override void Move()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        spriteRenderer.flipX = direction.x < 0.0f;
        if (isGrounded) { State = State.Run; }
    }

    protected void Jump()
    {
        rigidbody.AddForce(transform.up,ForceMode2D.Impulse); // Или force, но подбери нужную силу для достаточного прыжка от пола.
    }

    protected void CheckGroung()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colliders.Length > 1;

        if (!isGrounded) { State = State.Jump; }
    }

    private State State
    {
        get { return (State)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
}


public enum State
{
    Idle = 0,
    Run = 1,
    Jump = 2 // Другие анимации боя, смерти и действий.
}
