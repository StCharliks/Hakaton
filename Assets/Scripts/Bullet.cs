using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damage = 1;
	public bool isEnemy;

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


    void OnTriggerEnter2D(Collider2D coll)
	{
		if(!coll.isTrigger)
		{
			if(coll.transform.CompareTag("Wall"))
			{
				Destroy(gameObject);
			}

            if (coll.transform.CompareTag("Block"))
			{
				Destroy(coll.transform.gameObject);
				Destroy(gameObject);
			}
			
			if(!isEnemy)
			{
				if(coll.transform.CompareTag("Enemy"))
				{
					EnemyControl enemy = coll.transform.GetComponent<EnemyControl>();
					enemy.HP -= damage;
					Destroy(gameObject);
				}
			}
			else
			{
				if(coll.transform.CompareTag("Player"))
				{
					PlayerControl player = coll.transform.GetComponent<PlayerControl>();
					player.HP -= damage;
					Destroy(gameObject);
				}
			}
		}
	}
}
