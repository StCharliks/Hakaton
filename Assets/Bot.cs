using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour {
    public Rigidbody2D bullet;
    public float speed = 3.0f;
    public float obtacleRange = 50.0f;
    private float rotationSpeed = 5.0f;
    private float criticalWallDistance = 10f;
    private float bulletSpeed = 6f;
    private List<NavMeshAgent> navAgents;
    public Transform targetMarker;
    public Transform gun;
    private Rigidbody2D tankRigidBody;
    public PlayerControl player;
    public GameObject lootStorage;
    public List<GameObject> artifacts;
    public ContactFilter2D filter;
    private float currentAngle = 0;
    

    Rigidbody2D GetRigidBody
    {
        get
        {
            if (!tankRigidBody) tankRigidBody = GetComponent<Rigidbody2D>();

            return tankRigidBody;
        }
    }
    // Use this for initialization
    private void OnBulletSee()
    {

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        transform.Rotate(new Vector3(0, 0, 180));
    }


    private RaycastHit2D[] scan()
    {
        List<RaycastHit2D> result = new List<RaycastHit2D>();
        for (int i = 0; i <= 360; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0,0,i), obtacleRange, filter.layerMask);
            if (hit != null)
                result.Add(hit);     
        }

        return result.ToArray();
    }


    private void MakeDesition(RaycastHit2D[] data)
    {
        foreach (RaycastHit2D rh2d in data)
        {
            if (rh2d.collider.gameObject.name == "player(clone)")
            {
                GetRigidBody.MovePosition(transform.position + (-transform.up) * Time.deltaTime * speed);

                currentAngle = Random.Range(90, 180);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, currentAngle), Time.deltaTime * rotationSpeed);

                Rigidbody2D bulletInstance = Instantiate(bullet, gun.position, Quaternion.identity) as Rigidbody2D;
                bulletInstance.velocity = gun.TransformDirection(Vector2.up * bulletSpeed);
                return;
            }
        }
    }


    void Start () {
        gun = transform.GetComponent<Collider2D>().gameObject.GetComponent<EnemyControl>().gun;
        player = GetComponent<PlayerControl>();
	}

    IEnumerator WaitFire()
    {
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine(WaitFire());
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
        Ray2D ray = new Ray2D(gun.transform.position, gun.transform.up);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.up, obtacleRange, filter.layerMask);
        if (hit != null)
        {
            if (hit.collider.gameObject.CompareTag("Wall") && hit.distance <= criticalWallDistance)
            {
                GetRigidBody.MovePosition(transform.position + (-transform.up) * Time.deltaTime * speed);

                currentAngle = Random.Range(90, 180);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, currentAngle), Time.deltaTime * rotationSpeed);
            }
            //Debug.LogError("Govno");
            if (hit.collider.gameObject.name == "Player(Clone)")
            {
                StartCoroutine(WaitFire());
                GetRigidBody.MovePosition(transform.position + transform.up * Time.deltaTime * speed);

                Vector3 diff = hit.transform.position - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), Time.deltaTime * rotationSpeed);
            }
            if (hit.collider.gameObject.name == "coin(clone)")
                Debug.Log("COIN!!!");
            if (hit.collider.gameObject.name == "enemy(clone)")
                Debug.Log("HYI");
        }
        else
        {
            GetRigidBody.MovePosition(transform.position + transform.up * Time.deltaTime * speed);
            currentAngle += Vector2.Angle(player.transform.position, transform.position);
            Debug.Log("else angle" + currentAngle.ToString());
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, currentAngle), Time.deltaTime * rotationSpeed);
        }
    }
}
