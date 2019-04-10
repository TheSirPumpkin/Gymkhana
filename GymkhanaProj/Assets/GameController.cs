using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
  
    public GameObject ResumeButton;
    public GameObject TimeOver;
    bool multi;
    public Text singleScore, singleTimer;
    public GameObject PauseCanvas;
    public GameObject p1YellowWin, p1YellowLose, p1BlackTop, p1BlackBot, p2YellowWin, p2YellowLose, p2BlackTop, p2BlackBot;
    [HideInInspector]
    public GameObject p1Plus, p1Minus, p2Plus, p2Minus;
    public GameObject singlePlayer, multiPlayer, player1CarsObj, player2CarsObj;
    public static GameController instance;
    public GameObject[] player1Cars, player2Cars;
    public Text score1,score11, score2,score22;
    public  GameObject[] players;
    public RCC_CameraConfig p1, p2;
   public int player1Points, player2Points;
    public Text timer1, timer2;
    float Timer;
    public GameObject levelEnd1, levelEnd2;
    public GameObject player1Won, player2Won, DRAW1, DRAW2, player1Lose, player2Lose;
    bool levelOver;
    [HideInInspector]
   public AudioSource[] sources;
    void OnEnable()
    {

    }

   
        private void Awake()
   
        {
        instance = this;
        if (PlayerPrefs.GetInt("Single") == 1)
        {
            multi = false;

            player1CarsObj.SetActive(true);
            singlePlayer.SetActive(true);
        }
        else
        {
            multi = true;
            player1CarsObj.SetActive(true);
            player2CarsObj.SetActive(true);
            multiPlayer.SetActive(true);
        }
    }
    // Use this for initialization
    void Start () {
        levelOver = false;
        Time.timeScale = 1;
        p1Plus = GameObject.FindGameObjectWithTag("PlayerOnePlus");
        p1Minus= GameObject.FindGameObjectWithTag("PlayerOneMinus");
        p2Plus = GameObject.FindGameObjectWithTag("PlayerTwoPlus");
        p2Minus = GameObject.FindGameObjectWithTag("PlayerTwoMinus");
        p1Plus.SetActive(false);
        p1Minus.SetActive(false);
        if (p2Plus && p2Minus)
        {
            p2Plus.SetActive(false);
            p2Minus.SetActive(false);
        }
        AudioListener.volume = PlayerPrefs.GetInt("Sound");
        Timer = 120;
        player1Cars[PlayerPrefs.GetInt("Player1Car")].SetActive(true);
        player2Cars[PlayerPrefs.GetInt("Player2Car")].SetActive(true);
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            if (player.GetComponent<RCC_CameraConfig>()){
                if (player.GetComponent<RCC_CameraConfig>().player == 1) p1 = player.GetComponent<RCC_CameraConfig>();
                if (player.GetComponent<RCC_CameraConfig>().player == 2) p2 = player.GetComponent<RCC_CameraConfig>();
            }
        }
        sources = GameObject.FindObjectsOfType<AudioSource>();
    }
    public void BackToMenu()
    {
        Garter.I.CallAd(2);
        if (PlayerPrefs.GetInt("Free") ==1&& PlayerPrefs.GetInt("Single") == 1)
        {
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + player1Points);
            levelOver = true;

        }
        Application.LoadLevel(0);
    }
  
    public void Pause()
    {
        Garter.I.CallAd(2);
      //  sources = GameObject.FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if(source)
            source.gameObject.SetActive(false);
            // maxEngineSoundVolume = 0;
        }

        //Debug.Log("Paused");
        // if (!levelOver)
        // {
        singlePlayer.SetActive(false);
            multiPlayer.SetActive(false);
      //  }
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            AudioListener.volume = 0;
            return;
        
    }
    public void Resume()
    {
        if (!levelOver)
        {
            //sources = GameObject.FindObjectsOfType<AudioSource>();
            foreach (AudioSource source in sources)
            {
                if(source)
              source.gameObject.SetActive(true);
               // maxEngineSoundVolume = 0;
            }
            //Debug.Log("Resume");
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
            AudioListener.volume = PlayerPrefs.GetInt("Sound");
            if (PlayerPrefs.GetInt("Single") == 1)
            {

                singlePlayer.SetActive(true);
            }
            else
            {

                multiPlayer.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {if (PauseCanvas.activeSelf == true)
        {
            AudioListener.volume = 0;
               Time.timeScale = 0;
        }
        if (levelOver) ResumeButton.SetActive(false);
        if (Input.GetKeyDown(KeyCode.P)&&Timer> 0 && !levelOver && PlayerPrefs.GetInt("Free") == 0|| PlayerPrefs.GetInt("Free") == 1&& Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.P) && Timer <= 0 && PlayerPrefs.GetInt("Free") == 0 )
        {
            BackToMenu();
        }
        if (PlayerPrefs.GetInt("Free") == 0)
        {
            Timer -= Time.deltaTime;
        }
        if (!multi)
        {
            if (p1.points < 0) p1.points = 0;
            player1Points = p1.points;
            if (PlayerPrefs.GetInt("Free") == 0&& Timer>=0)
                singleTimer.text = "" + (int)Timer;
            else singleTimer.text = "";
            singleScore.text = "" + player1Points;
            if(Timer <= 0&&!levelOver&& PlayerPrefs.GetInt("Free") == 0)
            {
                Garter.I.CallAd(2);
             //   sources = GameObject.FindObjectsOfType<AudioSource>();
                foreach (AudioSource source in sources)
                {
                    if (source)
                        source.gameObject.SetActive(false);
                    // maxEngineSoundVolume = 0;
                }
                PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points")+ player1Points*2);
                Time.timeScale = 0;
                TimeOver.SetActive(true);
                levelOver = true;

            }
        }
       
        if (multi)
        {
            if (PlayerPrefs.GetInt("Free") == 0)
                timer1.text = "" + (int)Timer;
            else timer2.text = "";
            if (PlayerPrefs.GetInt("Free") == 0)
                timer2.text = "" + (int)Timer;
            else timer2.text = "";
            if (Timer <= 0 && !levelOver)
            {
                Garter.I.CallAd(2);
             //   sources = GameObject.FindObjectsOfType<AudioSource>();
                foreach (AudioSource source in sources)
                {
                    if (source)
                        source.gameObject.SetActive(false);
                    // maxEngineSoundVolume = 0;
                }
                Time.timeScale = 0;
                if (player1Points > player2Points)
                {
                    player1Won.SetActive(true);
                    player2Lose.SetActive(true);
                }
                if (player2Points > player1Points)
                {
                    player2Won.SetActive(true);
                    player1Lose.SetActive(true);

                }

                if (player2Points == player1Points)
                {
                    DRAW1.SetActive(true);
                    DRAW2.SetActive(true);
                }

                levelEnd1.SetActive(true);
                levelEnd2.SetActive(true);

                levelOver = true;
            }
          
            if (p1.points < 0) p1.points = 0;
            if (p2.points < 0) p2.points = 0;
            player1Points = p1.points;
            player2Points = p2.points;
            if (player1Points >= player2Points)
            {
                p1YellowWin.SetActive(true);
                p1YellowLose.SetActive(false);
                p1BlackBot.SetActive(true);
                p1BlackTop.SetActive(false);

                p2YellowLose.SetActive(true);
                p2YellowWin.SetActive(false);
                p2BlackBot.SetActive(false);
                p2BlackTop.SetActive(true);
                score1.text = /*"Player1 LEADING "*/"" + player1Points;
                score2.text = /*"Player2 SASAI "*/"" + player2Points;
                score11.text =/* "Player1 LEADING "*/"" + player1Points;
                score22.text = /*"Player2 SASAI " */"" + player2Points;
            }
            else
            {
                p1YellowWin.SetActive(false);
                p1YellowLose.SetActive(true);
                p1BlackBot.SetActive(false);
                p1BlackTop.SetActive(true);

                p2YellowLose.SetActive(false);
                p2YellowWin.SetActive(true);
                p2BlackBot.SetActive(true);
                p2BlackTop.SetActive(false);
                score1.text = /*"Player2 LEADING "*/"" + player2Points;
                score2.text = /*"Player1 SASAI "*/ "" + player1Points;
                score11.text = /*"Player2 LEADING "*/ "" + player2Points;
                score22.text = /*"Player1 SASAI "*/ "" + player1Points;
            }
        }
    }

    public void VK()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://vk.com/lemur_interactive\")");
#endif
        //  Application.OpenURL("https://vk.com/lemur_interactive");
    }
    public void CrazyGames()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://www.crazygames.com/\")");
#endif
        //  Application.OpenURL("https://www.crazygames.com/");
    }
    public void GooglePlay()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"jopa\")");
#endif
        //  Application.OpenURL("jopa");
    }
    public void AppStore()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"jopa\")");
#endif
        //  Application.OpenURL("jopa");
    }
    public void Insta()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://www.instagram.com/lemur_interactive/\")");
#endif
        // Application.OpenURL("https://www.instagram.com/lemur_interactive/");
    }

    public void Face()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://www.facebook.com/groups/LEMURinteractive/\")");
#endif
        // Application.OpenURL("https://www.facebook.com/groups/LEMURinteractive/");
    }

    public void YouTube()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://www.youtube.com/channel/UCWi1pcZYkYcGXqUz1wuSSWA\")");
#endif
        //  Application.OpenURL("https://www.youtube.com/channel/UCWi1pcZYkYcGXqUz1wuSSWA");
    }

    public void Twitter()
    {
#if !UNITY_EDITOR
		Application.ExternalEval("window.open(\"https://twitter.com/LEMURInteract\")");
#endif
        //  Application.OpenURL("https://twitter.com/LEMURInteract");
    }

}
