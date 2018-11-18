using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int money;

    public Coin(int money)
    {
        this.money = money;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerControl player = other.gameObject.GetComponent<PlayerControl>();

            player.Cash += money;
            Destroy(gameObject);
        }
    }
}
