using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour {

    public PlayerControls controls;
    public GameObject snowballPrefab;

    private bool hasSnowball = false;
    private PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
        playerMovement = GetComponent<PlayerMovement>();

        // DEBUG
        hasSnowball = true;
        playerMovement.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasSnowball && Input.GetKeyDown(controls.Throw))
            ThrowSnowball();
	}

    private void ThrowSnowball() {
        Vector3 direction = Vector3.right; // default direction depends on player

        if (Input.GetKey(controls.Up))
            direction += Vector3.up;
        else if (Input.GetKey(controls.Down))
            direction += Vector3.down;

        GameObject snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
        snowball.GetComponent<Snowball>().direction = direction.normalized;

        hasSnowball = false;
        Invoke("EnableMovement", 1f);
    }

    private void EnableMovement() {
        playerMovement.enabled = true;
    }
}
