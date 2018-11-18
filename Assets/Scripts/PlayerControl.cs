using UnityEngine;
using Extensions;
using System.Linq;
using System;

public class PlayerControl : MonoBehaviour {

    public GameControl gc;
	public int HP = 2;
	public Transform explosion;
	public float speed = 2f;
	public Animator _animator;
	public Transform tank;
	public Transform gun;
	public Rigidbody2D bullet;
	public float bulletSpeed = 3f;
	public CheckMove check;
	private Rigidbody2D body;
    public GameObject coin;
	private Vector2 moveDirection;
	private Vector3 rotation;

    public static explicit operator PlayerControl(GameObject v)
    {
        throw new NotImplementedException();
    }

    private Vector2 normal = new Vector2(0, 1);
    private float angle;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    public int Cash
    {
        get; set;
    }

	void Start ()
	{
		_animator.speed = 1;
        moveDirection = normal;
		body = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        CameraController ctank = camera.GetComponent<CameraController>();
        ctank.tank = this;
        Cash = 100;
    }

    Rigidbody2D GetRigidBody
    {
        get
        {
            if (!body) body = GetComponent<Rigidbody2D>();

            return body;
        }
    }



    void Update() 
	{
        Debug.Log(Cash);
        //DropCoins();
        body.MovePosition(transform.position + transform.up * Time.deltaTime * speed);

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && gun)
        {
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }



        if (HP <= 0)
		{
			GameControl.playerDead = true;
			float randomZ = UnityEngine.Random.Range(0, 360f);
			Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, randomZ));
            DropCoins();
            GameControl.cash = Cash = 0;
			Destroy(gameObject);
		}
	}

    void DropCoins()
    {
        System.Random rnd = new System.Random(10);
        int numOfCoins = rnd.Next(1, 10);

        for (int i = 0; i < numOfCoins; i++)
        {
            coin.GetComponent<Coin>().money = rnd.Next(10, 100);
            Instantiate(coin, tank.transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360f) ));
        }
    }
}
