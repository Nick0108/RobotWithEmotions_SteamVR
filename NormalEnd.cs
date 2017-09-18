using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalEnd : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        text.text = GameManager.collectionNum + "/20";
	}

}
