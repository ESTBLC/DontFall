using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clignotement : MonoBehaviour {
    Text FlashingText;

	// Use this for initialization
	void Start () {
        FlashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
	}
	public IEnumerator BlinkText()
    {
        while (true)
        {
            FlashingText.text = "";
            yield return new WaitForSeconds(.2F);
            FlashingText.text = "Press any key";
            yield return new WaitForSeconds(.5F);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
