using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public enum PlayerNumber { One, Two }
    public PlayerNumber playerNum = PlayerNumber.One;
    private int DASH_FRAMES = 5;

    private Dictionary<string, KeyCode> playerOneControls = new Dictionary<string, KeyCode> {
        { "Up", KeyCode.W },
        {"Down", KeyCode.S },
        {"Left", KeyCode.A },
        {"Right", KeyCode.D },
        {"Dash", KeyCode.LeftShift }
    };

    private Dictionary<string, KeyCode> playerTwoControls = new Dictionary<string, KeyCode> {
        { "Up", KeyCode.UpArrow },
        {"Down", KeyCode.DownArrow },
        {"Left", KeyCode.LeftArrow },
        {"Right", KeyCode.RightArrow },
        {"Dash", KeyCode.RightShift }
    };

    private float movementSpeed = 0.2f;
    private float dashSpeed = 1.2f;
    private Dictionary<string, KeyCode> controls;
    private bool isDashing = false;
    private int dashFramesRemaining = 0;
    private Animator animator;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        controls = playerNum == PlayerNumber.One ? playerOneControls : playerTwoControls;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        bool isRunning = false;
        Vector3 finalPosition = transform.position;

        // Dashing
        if (Input.GetKeyDown(controls["Dash"]) && !isDashing)
        {
            isDashing = true;
            dashFramesRemaining = DASH_FRAMES;
        }
        float speed = isDashing ? dashSpeed : movementSpeed;

        // Up/down movement
        if (Input.GetKey(controls["Up"]))
        {
            finalPosition += Vector3.up * speed; 
            isRunning = true;
        }
        else if (Input.GetKey(controls["Down"]))
        {
            finalPosition += Vector3.down * speed;
            isRunning = true;
        }

        // Left/Right movement
        if (Input.GetKey(controls["Right"]))
        {
            finalPosition += Vector3.right * speed;
            isRunning = true;
        }
        else if (Input.GetKey(controls["Left"]))
        {
            finalPosition += Vector3.left * speed;
            isRunning = true;
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
}
