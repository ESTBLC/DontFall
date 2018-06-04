using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CubeDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PhotonView phV = other.GetComponent<PhotonView>();
            if (phV.isMine)
                PhotonNetwork.Destroy(phV);
        }
        else if(other.tag == "Bullet")
        {
            PhotonView phV = other.GetComponent<PhotonView>();
            if (phV.isMine)
                PhotonNetwork.Destroy(phV);
        }
    }
}
