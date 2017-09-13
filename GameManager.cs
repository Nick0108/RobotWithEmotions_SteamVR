using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Video;

public class GameManager : MonoBehaviour {
    
	public enum Chapter
    {
        Chapter1,
        Chapter2,
        Chapter3,
        Chapter4,
        Chapter5,
        Chapter6,
        Chapter7,
    }
    public static int collectionNum;
    public static Chapter currentChapter;
    public GameObject player;
    private SteamVR_LoadLevel LoadLevel;

    //for testing
    public Chapter ChangeChapter;
    public int killEnemyNum;
    public bool testing = false; 

    //Chapter1
    public PlayableDirector UTCplayable01;
    public Collectable startbook;
    public GameObject Happyball;
    public bool GetHappyBall = false;
    public GameObject UTC01;

    //Chapter2
    public PlayableDirector UTCplayable02;
    public GameObject UTC02;
    public bool start02 = false;
    private bool hasPlay = false;
    public DoorOpen door;
    public DoorOpen door2;

    //Chapter3
    public ChangeSkybox changeSkybox;
    public PlayableDirector UTCplayable03;
    public GameObject UTC03;
    public GameObject UTCObject;
    public Shader TransparentShader;
    public GameObject fearBall;
    public bool isChangeWeather = false;
    public bool isChangeWeather2 = false;
    public Collectable lamp;
    public DoorOpen PrincessDoor;
    public DoorOpen PrincessDoor2;
    public bool BeginToCry = false;
    public bool NotCry = false;
    public bool Disappear = false;
    public GameObject Elephant;
    public bool GetFearBall = false;
    private SkinnedMeshRenderer[] meshRenders;
    public AudioClip[] chapter3AudioClips;
    public AudioSource chapter3AudioSource;
    private float ToVoice2Timer;
    private bool isCp3Audio1Play = false;
    private bool isNotCry = false;
    private bool countTo2 = false;

	//Chapter4
    public GameObject TimeLine4;
    public bool GetAngryBall = false;
    public GameObject AngryBall;
    public PlayerHealth playerHealth;
    public float Cp4_ToVoice2Timer;
    private bool isVoice1Play = false;
    private bool beginCountToVoice2 = false;
    public AudioClip[] chapter4AudioClips;
    public AudioSource chapter4AudioSource;
    public AudioSource playerAudioSource;

	void Start () {
        collectionNum = 0;
        currentChapter = Chapter.Chapter1;
        LoadLevel = gameObject.GetComponent<SteamVR_LoadLevel>();
        //Chapter03
        meshRenders = UTCObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        CombineTimer = 0;
        trueEndTimer = 0;
        ToVoice2Timer = 0;
    }


	void update(){
		//Chapter01
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
        //Chapter02
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
        //Chapter03
        if (currentChapter == Chapter.Chapter3)
        {
            if (!isChangeWeather2)
            {
                if (PrincessDoor.EventNowHappen || PrincessDoor2.EventNowHappen)
                {
                    changeSkybox.currentSkyBox = ChangeSkybox.skybox.Night;
                    changeSkybox.CheckCurrentSky();
                    isChangeWeather = true;
                }
            }
            if (!isChangeWeather)
            {
                if (player.transform.position.x > 3f && player.transform.position.z < -15f)
                {
                    changeSkybox.currentSkyBox = ChangeSkybox.skybox.Falling;
                    changeSkybox.CheckCurrentSky();
                    isChangeWeather = true;
                }
            }
            if (lamp.EventNowHappen)
            {
                PrincessDoor.isLock = false;
                PrincessDoor2.isLock = false;
                UTCplayable03.Play();
                lamp.EventNowHappen = false;
                if (UTCObject.transform.localPosition != Vector3.zero)
                {
                    UTCObject.transform.localPosition = Vector3.zero;
                    UTCObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (!isCp3Audio1Play)
                {
                    chapter3AudioSource.clip = chapter3AudioClips[0];
                    chapter3AudioSource.loop = false;
                    chapter3AudioSource.Play();
                    isCp3Audio1Play = true;
                    countTo2 = true;
                }
            }
            if (countTo2)
            {
                ToVoice2Timer += Time.deltaTime;
                if (ToVoice2Timer > 18.5f)
                {
                    if (!chapter3AudioSource.isPlaying)
                    {
                        chapter3AudioSource.clip = chapter3AudioClips[1];
                        chapter3AudioSource.loop = true;
                        chapter3AudioSource.Play();
                        countTo2 = false;
                    }
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

		//Chapter04
        if (currentChapter == Chapter.Chapter4)
        {
            if(player.transform.position.z > -13f)
            {
                if (!isVoice1Play)
                {
                    chapter4AudioSource.clip = chapter4AudioClips[0];
                    chapter4AudioSource.loop = false;
                    chapter4AudioSource.Play();
                    isVoice1Play = true;
                    beginCountToVoice2 = true;
                }
            }
            if (beginCountToVoice2)
            {
                Cp4_ToVoice2Timer += Time.deltaTime;
                if (Cp4_ToVoice2Timer > 7)
                {
                    playerAudioSource.Play();
                    chapter4AudioSource.clip = chapter4AudioClips[1];
                    chapter4AudioSource.loop = true;
                    chapter4AudioSource.Play();
                    beginCountToVoice2 = false;
                }
            }
            if (GetAngryBall)
            {
                playerHealth.HP.gameObject.SetActive(true);
                if (!playerHealth.Alive)
                {
                    LoadLevel.levelName = "BadEnd";
                    LoadLevel.Trigger();
                }
                else
                {
                    if (KillEnemyNum == 5)
                    {
                        chapter4AudioSource.clip = chapter4AudioClips[2];
                        chapter4AudioSource.loop = false;
                        chapter4AudioSource.Play();
                        TimeLine4.SetActive(false);
                        TimeLine5.SetActive(true);
                        currentChapter = Chapter.Chapter5;
                    }
                }
            }
	}
}
