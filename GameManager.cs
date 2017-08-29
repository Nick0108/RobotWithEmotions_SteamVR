using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Video;

public class GameManager : MonoBehaviour {
    
    public static int collectionNum;
    public GameObject player;

	void Start () {
        collectionNum = 0;
    }
}
