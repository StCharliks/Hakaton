using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using ButtonManager;

public class Records : MonoBehaviour
{

    public Text ScoresBoard;

    void Start ()
    {
        ScoresBoard.text = "";
        for (int i = 0; i < ButtonManager.recordTable.Count; i++)
        {
            ScoresBoard.text = ScoresBoard.text + ButtonManager.recordTable[i].Name + ' ' + ButtonManager.recordTable[i].Score + "\n";
        }
    }

  //  List<String> data = File.ReadAllLines(pfad + datei)
  //  .Concat(File.ReadAllLines(pfad2 + datei2))
  //  .Distinct().ToList();

}
