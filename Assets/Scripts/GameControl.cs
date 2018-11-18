﻿using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using Expload.Pravda.ExploadCryptoBattleProgram;
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

    void OnKeyPressed()
    {
        var address = Utils.ConvertHexStringToByteArray("d3dcbb39c14c06eea895acbf7bc4ae7450c5906be6c97d06090b2d7a1e698392");
        var req = new CreateArtifactRequest(address);

        Debug.Log(req.TransactionId);

        if (req.IsError)
        {
            Debug.LogError(req.Error);
        }
        else
        {
            Debug.Log(req.Result);
        }
    }

	void Update() 
	{
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnKeyPressed();
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
