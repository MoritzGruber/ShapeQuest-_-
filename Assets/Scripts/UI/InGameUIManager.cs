using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class InGameUIManager : MonoBehaviour {

    public GameObject escMenuPanel;

    NetworkManager netMan;

    // Update is called once per frame
    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            escMenuPanel.SetActive(!escMenuPanel.activeSelf);
        }
        if (netMan == null)
        {
            netMan = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        }
    }

    public void ExitButton()
    {
        netMan.StopHost();
        Application.Quit();
    }

    public void DisconnectButton()
    {
        netMan.StopHost();
    }



}
