using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour {

    public InputField Username;

	public void setget()
    {
        ButtonManager.Username = Username.text;
    }

}
