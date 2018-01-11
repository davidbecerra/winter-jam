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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boundary")) {
            if (collision.gameObject.CompareTag("Bouncable")) {
                Vector3 normal = collision.gameObject.name == "Top Wall" ? Vector3.down : Vector3.up;
                BounceOffWall(normal);
            }
            else
                Destroy(gameObject);
        }
    }

    private void BounceOffWall(Vector3 normal) {
        direction.y *= -1f;
    }
}
