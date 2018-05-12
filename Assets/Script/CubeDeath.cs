using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CubeDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PhotonView phV = other.GetComponent<PhotonView>();
        if (phV.isMine)
            PhotonNetwork.Destroy(phV);
    }


}
