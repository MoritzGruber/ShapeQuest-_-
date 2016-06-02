using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUIManager : MonoBehaviour {

    public GameObject escMenuPanel; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            escMenuPanel.SetActive(!escMenuPanel.activeSelf);
        }
    }

    public void ExitButton()
    {

    }

    public void DisconnectButton()
    {

    }



}
