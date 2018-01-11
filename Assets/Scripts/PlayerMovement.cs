using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public enum PlayerNumber { One, Two }
    public PlayerNumber playerNum = PlayerNumber.One;
    public GameObject snowballPrefab;
    public PlayerControls controls;

    private int DASH_FRAMES = 5;
    private float movementSpeed = 0.2f;
    private float dashSpeed = 1.2f;
    private bool isDashing = false;
    private int dashFramesRemaining = 0;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovement();

        //if (Input.GetKeyDown(controls.Throw))
        //{
        //    GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
        //    snowball.GetComponent<Snowball>().direction = playerNum == PlayerNumber.One ? Vector3.right : Vector3.left;
        //    snowball.GetComponent<Snowball>().source = playerNum;
        //}
    }

    private void UpdateMovement()
    {
        bool isRunning = false;
        Vector3 finalPosition = transform.position;

        // Dashing
        if (Input.GetKeyDown(controls.Dash) && !isDashing)
        {
            isDashing = true;
            dashFramesRemaining = DASH_FRAMES;
        }
        float speed = isDashing ? dashSpeed : movementSpeed;

        // Up/down movement
        if (Input.GetKey(controls.Up))
        {
            finalPosition += Vector3.up * speed;
            isRunning = true;
        }
        else if (Input.GetKey(controls.Down))
        {
            finalPosition += Vector3.down * speed;
            isRunning = true;
        }

        // Left/Right movement
        if (Input.GetKey(controls.Left))
        {
            finalPosition += Vector3.left * speed;
            isRunning = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey(controls.Right))
        {
            finalPosition += Vector3.right * speed;
            isRunning = true;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


        // Move to final position
        rigidBody.MovePosition(finalPosition);

        // Play moving animation
        animator.SetBool("IsRunning", isRunning);

        // Dashing
        if (dashFramesRemaining > 0)
        {
            --dashFramesRemaining;
        }

        if (dashFramesRemaining == 0)
        {
            isDashing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snowball" && collision.gameObject.GetComponent<Snowball>().source != playerNum)
        {
            Destroy(collision.gameObject);
            Hit();
        }
    }

    void Hit()
    {
        //InvokeRepeating("Flash", 0f, 0.25f);
        //StartCoroutine(Flash(4));
    }

    //IEnumerator Flash(int flashCounter)
    //{
    //    while (flashCounter > 0)
    //    {
    //        spriteRenderer.enabled = !spriteRenderer.enabled;
    //        yield return 0;
    //    }
    //    yield return 0;
    //}
}
