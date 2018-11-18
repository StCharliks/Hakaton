using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D bulletRigidBody;

    Rigidbody2D GetRigidBody
    {
        get
        {
            if (!bulletRigidBody) bulletRigidBody = GetComponent<Rigidbody2D>();
            return bulletRigidBody;
        }
    }

    void Update()
    {
        GetRigidBody.MovePosition(transform.position + transform.up * Time.deltaTime * speed);
    }
}
