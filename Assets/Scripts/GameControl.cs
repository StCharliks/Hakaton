using UnityEngine;
using System.Collections;
using Expload.Pravda.ExploadCryptoBattleProgram;
using Expload.Unity.Codegen;
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

    IEnumerator OnKeyPressed(int command)
    {
        var address =
            Utils.ConvertHexStringToByteArray("b7735e8d2b7852cd953392311855ccc5e70ee4e38371dc18ed42ffd66b5d60d7");
        var param1 =
            Utils.ConvertHexStringToByteArray("3b8b7459b5072e6006bbcb4fd8808d9cd916a3a729dd03dfa7eae8f84883e57a");
        var param2 =
            Utils.ConvertHexStringToByteArray("edb4fe9c21fe2e53c2168234d79fd30100ddd8447bd6f4c78e52f0dee35286aa");

        switch (command)
        {
            case 1:
                var req1 = new CreateArtefactRequest(address);
                yield return req1.CreateArtefact(param1);
                HandleResult(req1);
                break;
            case 2:
                var req2 = new TransferArtefactRequest(address);
                yield return req2.TransferArtefact(2, param2);
                HandleResult(req2);
                break;
            case 3:
                var req3 = new GetOwnerRequest(address);
                yield return req3.GetOwner(1);
                HandleResult(req3);
                break;
            case 4:
                var req4 = new GetServerAddressRequest(address);
                yield return req4.GetServerAddress();
                HandleResult(req4);
                break;
            case 5:
                var req5 = new GetArtefactAtPosRequest(address);
                yield return req5.GetArtefactAtPos(param1, 1);
                break;
            case 6:
                var req6 = new GetArtefactsRequest(address);
                yield return req6.GetArtefacts(param1);
                break;
            default:
                break;
        }
    }

    void HandleResult<T>(ProgramRequest<T> req)
    {
        if (req.IsError)
        {
            Debug.LogError(req.Error);
        }
        else
        {
            Debug.LogError("SUCCESS: " + req.Result);
        }
    }

    void Update() 
	{
	    if (Input.GetKeyDown(KeyCode.Q))
	    {
	        var result = StartCoroutine(OnKeyPressed(1));
	    }
	    if (Input.GetKeyDown(KeyCode.W))
	    {
	        var result = StartCoroutine(OnKeyPressed(2));
	    }
	    if (Input.GetKeyDown(KeyCode.E))
	    {
	        var result = StartCoroutine(OnKeyPressed(3));
	    }
	    if (Input.GetKeyDown(KeyCode.R))
	    {
	        var result = StartCoroutine(OnKeyPressed(4));
	    }
	    if (Input.GetKeyDown(KeyCode.T))
	    {
	        var result = StartCoroutine(OnKeyPressed(5));
	    }
	    if (Input.GetKeyDown(KeyCode.Y))
	    {
	        var result = StartCoroutine(OnKeyPressed(6));
	    }

        RandomInstanciateCoin();
        earnedMoney.text = "Balance: " + cash.ToString();
        Debug.Log(string.Format("Player: {0}",cash));
        if (playerDead)
		{
            playerDead = false;
            Instantiate(player, playerSpawn.position, Quaternion.identity);
            //SceneManager.LoadScene("FillName", LoadSceneMode.Single);
        }
	}

    private void RandomInstanciateCoin()
    {
        if (Random.Range(0, 100) > 80)
        {
            //Instantiate(new Coin(50), new Vector3(new System.Random().Next(10, 100), new System.Random().Next(10, 100), -10), Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360f)));
        }
    }
}
