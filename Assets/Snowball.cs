using UnityEngine;

public class Snowball : MonoBehaviour {

    public Vector3 direction = Vector3.up;
    public PlayerMovement.PlayerNumber source;

    private float speed = 0.5f;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidBody.MovePosition(transform.position + direction * speed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) Destroy(gameObject);
    }
}
