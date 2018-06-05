using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonJoinRoom : MonoBehaviour
{
    public Text RoomName;
    public string TrueRoomName;
    public Menu MenuCanvas;

    private void Start()
    {
        MenuCanvas = FindObjectOfType<Menu>();
    }

    public void JoinRoom()
    {
        MenuCanvas.JoinRoom(TrueRoomName);
    }

}
