using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Video;

public class GameManager : MonoBehaviour {
    
    public static int collectionNum;
    public GameObject player;

	//action1
	public PlayableDirector UTCplayable;
    public Readable startbook;
    public GameObject Happyball;
    public bool Get = false;
    public GameObject UTC;

	//action2
	public class Action2 : MonoBehaviour {
    public PlayableDirector UTCplayable;
    public GameObject UTC;
    public bool start = false;
    private bool hasPlay = false;

	//action3
	public PlayableDirector UTCplayable;
    public GameObject UTC;
    public GameObject UTCObject;
    public Shader TransparentShader;

    public bool BeginToCry = false;
    public bool NotCry = false;
    public bool Disappear = false;

    public GameObject Elephant;

    private SkinnedMeshRenderer[] meshRenders;

	void Start () {
        collectionNum = 0;
		meshRenders = UTCObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    }


	void update(){
		//action1
		if (currentChapter == Chapter.Chapter1)
        {
            if (startbook.EventNowHappen)
            {
                UTCplayable01.Play();
                startbook.EventNowHappen = false;
            }
            if (GetHappyBall)
                UTCplayable01.Resume();
            else if (UTCplayable01.time > 12.42)
            {
                UTCplayable01.Pause();
                Happyball.SetActive(true);
            }

            if (UTCplayable01.time > 19.15)
            {
                UTCplayable01.Stop();
                UTC01.SetActive(false);
                currentChapter = Chapter.Chapter2;
            }
        }
		//action2
		if (currentChapter == Chapter.Chapter2)
        {
            if (door.isOpen || door2.isOpen)
            {
                start02 = true;
            }

            if (!hasPlay)
            {
                if (start02)
                {
                    UTCplayable02.Play();
                    hasPlay = true;
                }
            }
            if (UTCplayable02.time > 8.8)
            {
                UTC02.SetActive(false);
                currentChapter = Chapter.Chapter3;
            }
        }

		//action3

		if (currentChapter == Chapter.Chapter3)
		{
			
			if (!isChangeWeather)
			{
				if (player.transform.position.x > 3f && player.transform.position.z < -15f)
				{
					changeSkybox.currentSkyBox = ChangeSkybox.skybox.Falling;
					changeSkybox.CheckCurrentSky();
					isChangeWeather = true;
				}
			}
			
			if (NotCry)
			{
				if (!isNotCry)
				{
					foreach (SkinnedMeshRenderer M in meshRenders)
					{
						M.material.shader = TransparentShader;
					}
					chapter3AudioSource.clip = chapter3AudioClips[2];
					chapter3AudioSource.loop = true;
					chapter3AudioSource.Play();
					isNotCry = true;
				}
			}
			if (Disappear)
			{
				UTC03.SetActive(false);
				UTCplayable03.Stop();
				Elephant.GetComponent<Rigidbody>().isKinematic = false;
				fearBall.SetActive(true);
				Disappear = false;
				chapter3AudioSource.loop = false;
				chapter3AudioSource.Stop();
			}
			if (GetFearBall)
			{
				TimeLine4.SetActive(true);
				currentChapter = Chapter.Chapter4;
			}
		}
	}
}
