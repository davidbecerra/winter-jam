using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public enum PlayerNumber { One, Two }
    public PlayerNumber playerNum = PlayerNumber.One;

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

    private float movementSpeed = 0.5f;
    private float dashSpeed = 1.5f;
    private Dictionary<string, KeyCode> controls;

	// Use this for initialization
	void Start () {
        controls = playerNum == PlayerNumber.One ? playerOneControls : playerTwoControls;
	}
	
	// Update is called once per frame
	void Update () {
        float speed = Input.GetKey(controls["Dash"]) ? dashSpeed : movementSpeed;
        if (Input.GetKey(controls["Up"]))
        {
            transform.Translate(Vector3.up * speed);
        }
        if (Input.GetKey(controls["Down"]))
        {
            transform.Translate(Vector3.down * speed);
        }
        if (Input.GetKey(controls["Right"]))
        {
            transform.Translate(Vector3.right * speed);
        }
        if (Input.GetKey(controls["Left"]))
        {
            transform.Translate(Vector3.left * speed);
        }

    }
}
