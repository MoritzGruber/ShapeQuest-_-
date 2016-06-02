using UnityEngine;
using System.Collections;

public class StorePlayerData : MonoBehaviour
{
    public string playerName;
    public string playerColor;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
