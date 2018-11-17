using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    public PlayerControl tank;
    [SerializeField]
    private float speed = 3f;
	// Update is called once per frame
	void FixedUpdate () {
        if (tank)
            transform.position = Vector3.Lerp(transform.position, tank.transform.position + new Vector3(0, 0, -10), Time.deltaTime * speed);
    }
}
