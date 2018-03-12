using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateComponents : MonoBehaviour {

    [SerializeField]
    private Behaviour[] toDisable;
	// Use this for initialization
	public void Desactivate()
    {
        int l = toDisable.Length;
        for (int i = 0; i < l; i++)
        {
            toDisable[i].enabled = false;
            Debug.Log(toDisable[i].gameObject.name + " desactivate");
        }
	}
}
