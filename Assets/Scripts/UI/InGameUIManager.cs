using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class InGameUIManager : MonoBehaviour {

    public GameObject escMenuPanel;

    NetworkManager netMan;

    /**
     * <summary>Checks if hit escape and if so tooglels the menus active state
     *          also if no NetworkManager has ben assinged it assings a NetworkManager given that one exists in the Scene</summary> 
     */
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

    /**
     * <summary>Called when the Exit button is clicked
     *          terminates network connections and Closes the Application</summary> 
     */
    public void ExitButton()
    {
        netMan.StopHost();
        Application.Quit();
    }

    /**
     * <summary>Called when the Disconnect button is clicked
     *          Disconnects the Player from the host if the Player is the host it closes the host</summary> 
     */
    public void DisconnectButton()
    {
        netMan.StopHost();
    }



}
