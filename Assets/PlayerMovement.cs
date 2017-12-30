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

	// Use this for initialization
	void Start () {
        controls = playerNum == PlayerNumber.One ? playerOneControls : playerTwoControls;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool isRunning = false;

        if (Input.GetKeyDown(controls["Dash"]) && !isDashing)
        {
            isDashing = true;
            dashFramesRemaining = DASH_FRAMES;
        }
        float speed = isDashing ? dashSpeed : movementSpeed;
        if (Input.GetKey(controls["Up"]))
        {
            transform.Translate(Vector3.up * speed);
            isRunning = true;
        }
        if (Input.GetKey(controls["Down"]))
        {
            transform.Translate(Vector3.down * speed);
            isRunning = true;
        }
        if (Input.GetKey(controls["Right"]))
        {
            transform.Translate(Vector3.right * speed);
            isRunning = true;
        }
        if (Input.GetKey(controls["Left"]))
        {
            transform.Translate(Vector3.left * speed);
            isRunning = true;
        }

        animator.SetBool("IsRunning", isRunning);

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
