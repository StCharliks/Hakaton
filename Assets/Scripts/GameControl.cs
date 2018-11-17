using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static readonly string[] levels = {"Game", "Level2", "Level3", "FillName"};
    public static int level = 0;
    public static bool playerDead;
	public static int score = 0;
    public static int cash = 0;
    public static int kills;
	public Transform[] enemySpawn;
	public float enemySpawnTime = 30;
	public int maxEnemy = 5;
	public Transform playerSpawn;
	public PlayerControl player;
	public GameObject enemy;
	public Text scoreText;
	public Text tankText;
    public Text earnedMoney;

    void Start() 
	{
        maxEnemy = maxEnemy * 3;
		playerDead = false;
		//score = 0;
        kills = 0;
		Instantiate(player, playerSpawn.position, Quaternion.identity);
		StartCoroutine (WaitEnemySpawn(enemySpawnTime));
	}

    IEnumerator WaitEnemySpawn(float t)
	{
		foreach(Transform obj in enemySpawn)
		{
			maxEnemy--;
			Instantiate(enemy, obj.position, Quaternion.identity);
		}
		yield return new WaitForSeconds (t);
		if(maxEnemy > 0) StartCoroutine (WaitEnemySpawn(enemySpawnTime));
	}

    void OnGUI()
    {
        scoreText.text = score.ToString();
        tankText.text = "Tank:\n" + maxEnemy;
        Debug.Log(string.Format("Player: {0}", player.Cash));
        earnedMoney.text = "Balance: " + cash.ToString();
    }

	void Update() 
	{
        earnedMoney.text = "Balance: " + player.Cash.ToString();
        Debug.Log(string.Format("Player: {0}", player.Cash));
        if (playerDead)
		{
            playerDead = false;
            Instantiate(player, playerSpawn.position, Quaternion.identity);
            //SceneManager.LoadScene("FillName", LoadSceneMode.Single);
        }
	}
}
