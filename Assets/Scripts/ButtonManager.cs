using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public struct PlayerInfo
    {
        public string Name;
        public int Score;
    }
    public static List<PlayerInfo> recordTable = new List<PlayerInfo>();

    PlayerInfo entry = new PlayerInfo();
    public static string Username;
    

    public void NewGameButton(string Game)
    {
        GameControl.level = 0;
        GameControl.score = 0;
        SceneManager.LoadScene(Game, LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ToMainMenuButton(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu, LoadSceneMode.Single);
    }

    public void RecordsFromMenuButton(string RecordsScene)
    {
        SceneManager.LoadScene(RecordsScene, LoadSceneMode.Single);
    }

    public void RecordsButton(string RecordsScene)
    {
        entry.Name = Username;
        entry.Score = GameControl.score;
        recordTable.Add(entry);
        SceneManager.LoadScene(RecordsScene, LoadSceneMode.Single);
    }

}
