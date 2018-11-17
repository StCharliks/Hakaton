using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public float speed = 5f;
    public float speedRotation = 2f;
    public Rigidbody2D tankRigidBody;

    public GameObject bullet;
    public GameObject bulletSpawner;

    Rigidbody2D GetRigidBody {
        get {
            if (!tankRigidBody) tankRigidBody = GetComponent<Rigidbody2D>();

            return tankRigidBody;
        }
    }

	void Update () {
       
        GetRigidBody.MovePosition(transform.position + transform.up * Time.deltaTime * speed);

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), Time.deltaTime * speedRotation);

        if (Input.GetKeyDown(KeyCode.Space) && bulletSpawner) {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        }
    }
}
