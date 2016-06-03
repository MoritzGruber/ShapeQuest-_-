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


    /**
     * <summary>return the stored color as Color object</summary> 
     * <returns>color a Color object created from the currentpolayerColor string</returns>
     */
    public Color GetPlayerColor()
    {
        byte r = byte.Parse(playerColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(playerColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(playerColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        Color color = new Color(r, g, b, 255);

        return color;
    }

    //TODO: add this on cube shere or stuff creation [in networked player] do so by making a command change color
    public void SetColorToGameObject(GameObject go, Color color)
    {
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.SetColor("_Color", color);
    }

}
