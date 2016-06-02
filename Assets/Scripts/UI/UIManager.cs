using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public InputField playerNameInput;
    public InputField playerColorInput;
    public InputField serverIPInput;
    public InputField serverPortInput;


    public string playerName;
    public string playerColor;
    public string serverIP;
    public string serverPort;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerName = playerNameInput.text;
        playerColor = playerColorInput.text;
        serverIP    = serverIPInput.text;
        serverPort  = serverPortInput.text;

    }

    public void JoinButtonClicked()
    {

    }

    public void HostButtonClicked()
    {

    }

}
