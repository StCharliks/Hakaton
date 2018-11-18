using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ButtonManager : MonoBehaviour
{
    public static string Username;

    public void NewGameButton(string scene)
    {
        GameControl.level = 0;
        GameControl.score = 0;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    /*public void Button()
    {
        Inventory.AddItem(new Item());
    }*/

    public void ToMainMenuButton(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void InventoryButton(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void MarketButton(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
