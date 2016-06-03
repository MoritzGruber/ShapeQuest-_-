using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
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

    NetworkManager netMan;
    StorePlayerData playerData;

    void Start()
    {

        if (playerData == null)
        {
            playerData = GameObject.Find("NetworkManager").GetComponent<StorePlayerData>();
        }

        if (playerData != null)
        {
            playerNameInput.text = playerData.playerName;
            playerColorInput.text = playerData.playerColor;
        }
    }

    void Update ()
    {
        playerName = playerNameInput.text;
        playerColor = playerColorInput.text;
        serverIP    = serverIPInput.text;
        serverPort  = serverPortInput.text;
        if (netMan == null)
        {
            netMan = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        }
        if (playerData == null)
        {
            playerData = GameObject.Find("NetworkManager").GetComponent<StorePlayerData>();
        }
    }

    public void JoinButtonClicked()
    {
        SetPlayerData();

        if (serverIP == "")
        {
            serverIP = "localhost";
        }
        netMan.networkAddress = serverIP;
        if (serverPort == "")
        {
            serverPort = "7777";
        }
        netMan.networkPort = int.Parse(serverPort);

        netMan.StartClient();
    }

    public void HostButtonClicked()
    {
        SetPlayerData();

        if (serverPort == "")
        {
            serverPort = "7777";
        }

        netMan.networkPort = int.Parse(serverPort);
        
        netMan.StartHost();
    }

    private void SetPlayerData()
    {
        playerData.playerName = playerName;
        playerData.playerColor = playerColor;

    }
}
