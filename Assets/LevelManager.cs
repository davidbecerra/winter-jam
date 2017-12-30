using UnityEngine;
using UnityEditor.SceneManagement;

public class LevelManager : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
            EditorSceneManager.LoadScene("Main");
	}
}
