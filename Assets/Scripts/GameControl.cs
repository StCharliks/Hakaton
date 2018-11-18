using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
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
        var address = Utils.ConvertHexStringToByteArray("d49861052c87e021e04a21b0e99345edfb669d5ad6e05e7b2c3dc5bb8793ecee");
        var param1 =
            Utils.ConvertHexStringToByteArray("3b8b7459b5072e6006bbcb4fd8808d9cd916a3a729dd03dfa7eae8f84883e57a");

        var param2 =
            Utils.ConvertHexStringToByteArray("edb4fe9c21fe2e53c2168234d79fd30100ddd8447bd6f4c78e52f0dee35286aa");
        //it works: return int
        //var req = new GetBalanceOfRequest(address);
        //yield return req.GetBalanceOf(param1);

        switch (command)
        {
            case 1:
                //it works: return int
                //Добавляется новый артефакт адресу, возвращается Id артефакта
                var req1 = new CreateArtifactRequest(address);
                yield return req1.CreateArtifact(param1);
                HandleResult(req1);
                break;
            case 2:
                var req2 = new TransferArtifactRequest(address);
                yield return req2.TransferArtifact(param1, param2, 2);
                HandleResult(req2);
                break;
            case 3:
                //it works: return byte[]
                var req3 = new GetOwnerRequest(address);
                yield return req3.GetOwner(1);
                HandleResult(req3);
                break;
            case 4:
                var req4 = new GetServerAddressRequest(address);
                yield return req4.GetServerAddress();
                HandleResult(req4);
                break;
            default:
                break;
        }
    }

    void HandleResult<T>(ProgramRequest<T> req)
    {
        Debug.Log(req.TransactionId);
        if (req.IsError)
        {
            Debug.LogError(req.Error);
        }
        else
        {
            //string hex = BitConverter.ToString((byte[])(object)req.Result);
            Debug.LogError("Success: " + req.Result);
        }
    }

    void Update() 
	{
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var result = StartCoroutine(OnKeyPressed(1));
        }
	    if (Input.GetKeyDown(KeyCode.X))
	    {
	        var result = StartCoroutine(OnKeyPressed(2));
	    }
	    if (Input.GetKeyDown(KeyCode.C))
	    {
	        var result = StartCoroutine(OnKeyPressed(3));
	    }
	    if (Input.GetKeyDown(KeyCode.V))
	    {
	        var result = StartCoroutine(OnKeyPressed(4));
	    }

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
