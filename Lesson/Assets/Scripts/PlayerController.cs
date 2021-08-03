using UnityEngine;
using TMPro;
using Saving;
public class PlayerController : Singleton<PlayerController>
{







    bool canDash = true;

    [SerializeField] float cd;

    float cooldownDelta;








    [SerializeField] TextMeshProUGUI textbox;


    int lifePoints = 5;

    [SerializeField] [Range(0, 50)] public float moveSpeed = 8f;
    string playerName = "Player";
    public bool isGrounded = false;


    [SerializeField] float idleCd;

    bool idlePose = true;

    float cdDelta;


    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] [Range(0, 500)] private float jumpForce;


    Animator animator;

    [HideInInspector] public SpriteRenderer sr;
    PlayerAtk playerAtk;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerAtk = GetComponent<PlayerAtk>();
        textbox.text = SaveManager.Instance.state.playerName;
    }


    private void Awake()
    {
        CreateSingleton();
    }




    // Update is called once per frame
    void Update()
    {
        GetUserInput();
        Jump();
        AnimateCharacter();
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 4;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    //This doesn;t interferre with the game
    float SqrRoot(float number)
    {
        return Mathf.Sqrt(number);
    }
    void AnimateCharacter()
    {
        if (Input.GetKey(KeyCode.Mouse0) && playerAtk.canAttack == true)
     
        {
            idlePose = false;
            animator.Play("Attack Animation");
            cdDelta = idleCd;
        }
        if (idlePose == false)
        {
            cdDelta -= Time.deltaTime;

            if (cdDelta <= 0)
            {
                idlePose = true;
            }
        }



        if (playerAtk.isAttacking == true)
        {
            return;
        }



        float myNumber = SqrRoot(rb.velocity.x);



        if (rb.velocity.x > 0.25f)
        {
            animator.Play("Run Animation");
            sr.flipX = false;
        }
        else if (rb.velocity.x < -0.25f)
        {
            animator.Play("Run Animation");
            sr.flipX = true;
        }
        else if (idlePose == true)
        {
            animator.Play("Idle Animation");
        }




    
        

    }



    void GetUserInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
        {
            direction = new Vector2(1, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = new Vector2(-1, 0);

        }
        Debug.Log(direction.x);
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

   
}
