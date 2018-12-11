using UnityEngine;

public class CameraConroller : MonoBehaviour {

    [SerializeField]
    private float speedCam = 2.0f;

    [SerializeField]
    private Transform target;

	private void Awake ()
    {
		if (!target) { target = FindObjectOfType<Character>().transform; }
	}

	private void Update ()
    {
        Vector3 position = target.position;
        position.z = -10.0f;
        transform.position = Vector3.Lerp(transform.position, position, speedCam * Time.deltaTime);
	}
}
