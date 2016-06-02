using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerController : NetworkBehaviour
{

    public GameObject body;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
    }
}
