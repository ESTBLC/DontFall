using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static Dictionary<string, Player> playerDic = new Dictionary<string, Player>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void RegisterPlayer(string netId, Player player)
    {
        playerDic.Add(netId, player);
    }

    public static void UnRegisterPlayer(string netId)
    {
        playerDic.Remove(netId);
    }

    public static Player GetPlayer(string netId)
    {
        return playerDic[netId];
    }
}
