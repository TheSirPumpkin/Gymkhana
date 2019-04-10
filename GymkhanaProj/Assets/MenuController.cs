using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public GameObject Locked;
    public Text pointsText, carCost;
    public int ptsInt;
    public Color[] colors;
    public GameObject[] player1Cars, player2Cars;

    [ContextMenu("ClearPrefs")]
    void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetMode(int mode)
    {
        if (mode == 1)
        {  PlayerPrefs.SetInt("Player1Car", 0);
            foreach(GameObject car in player1Cars)
            {
                car.SetActive(false);
            }
            player1Cars[PlayerPrefs.GetInt("Player1Car")].SetActive(true);
            PlayerPrefs.SetInt("Single", 1);
        }
            if (mode == 2)
        {
          
            PlayerPrefs.SetInt("Single", 0);
        }
    }
    public void TimeAttack()
    {
        PlayerPrefs.SetInt("Free", 0);
    }
    public void FreeRide()
    {
        PlayerPrefs.SetInt("Free", 1);
    }
    public void Unlock()
    {
        //Debug.Log(PlayerPrefs.GetInt("Single"));
        if (PlayerPrefs.GetInt("Single") == 1)
        {
            foreach (GameObject car in player1Cars)
            {
                if (car.activeSelf == true&&ptsInt>= car.GetComponent<ColorChanger>().price)
                {
                    PlayerPrefs.SetInt("CarBought" + car.name, 1);
                    PlayerPrefs.SetInt("Player1Car", car.GetComponent<ColorChanger>().ID);
                    Locked.SetActive(false);
                    ptsInt -= car.GetComponent<ColorChanger>().price;
                    PlayerPrefs.SetInt("Points", ptsInt);



                }
            }
        }
    }
	void Start () {
        if (PlayerPrefs.GetInt("FirstStart") != 1)
        {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("FirstStart", 1);
            AudioListener.volume = PlayerPrefs.GetInt("Sound");
        }

        Garter.I.CallAd(1);
        ptsInt = PlayerPrefs.GetInt("Points");
        PlayerPrefs.SetInt("CarBought" + player1Cars[0].name,1);
Time.timeScale = 1;
       // PlayerPrefs.SetInt("Player1Car", 0);
       //  PlayerPrefs.SetInt("Player2Car", 0);
        player1Cars[PlayerPrefs.GetInt("Player1Car")].SetActive(true);
        player2Cars[PlayerPrefs.GetInt("Player2Car")].SetActive(true);
    }
    void ChangeCar(bool next, int player)
    {
        if (player == 1)
        {
            if (next)
            {
                for (int i = 0; i < player1Cars.Length; i++)
                {
                    if (player1Cars[i].activeSelf == true)
                    {
                        if (i < player1Cars.Length - 1)
                        {
                            player1Cars[i].SetActive(false);
                            if (PlayerPrefs.GetInt("Single") == 1)
                            {

                                if (PlayerPrefs.GetInt("CarBought" + player1Cars[i+1].name) == 1)
                                {
                                    PlayerPrefs.SetInt("Player1Car", i + 1);
                                }
                            } else PlayerPrefs.SetInt("Player1Car", i + 1);
                            player1Cars[i + 1].SetActive(true);
                           
                          
                            return;
                        }
                        if (i >= player1Cars.Length - 1)
                        {
                            player1Cars[i].SetActive(false);
                            player1Cars[0].SetActive(true);
                            if (PlayerPrefs.GetInt("Single") == 1)
                            {

                                if (PlayerPrefs.GetInt("CarBought" + player1Cars[0].name) == 1)
                                {
                                    PlayerPrefs.SetInt("Player1Car", 0);
                                }
                            }
                            else PlayerPrefs.SetInt("Player1Car", 0);


                            return;
                        }

                    }
                }
            }
            if (!next)
            {
                for (int i = player1Cars.Length - 1; i > -1; i--)
                {
                    if (player1Cars[i].activeSelf == true)
                    {
                        //Debug.Log(i);
                        if (i > 0)
                        {
                            player1Cars[i].SetActive(false);
                            if (PlayerPrefs.GetInt("Single") == 1)
                            {

                                if (PlayerPrefs.GetInt("CarBought" + player1Cars[i - 1].name) == 1)
                                {
                                    PlayerPrefs.SetInt("Player1Car", i - 1);
                                }
                            }
                            else PlayerPrefs.SetInt("Player1Car", i - 1);

                            player1Cars[i - 1].SetActive(true);
                            
                            return;
                        }
                        if (i <= 0)
                        {
                            player1Cars[i].SetActive(false);
                            player1Cars[6].SetActive(true);
                            if (PlayerPrefs.GetInt("Single") == 1)
                            {

                                if (PlayerPrefs.GetInt("CarBought" + player1Cars[6].name) == 1)
                                {
                                    PlayerPrefs.SetInt("Player1Car", 6);
                                }
                            }
                            else PlayerPrefs.SetInt("Player1Car", 6);

                            return;
                        }

                    }
                }
            }
        }

        if (player == 2)
        {
            if (next)
            {
                for (int i = 0; i < player2Cars.Length; i++)
                {
                    if (player2Cars[i].activeSelf == true)
                    {
                        if (i < player2Cars.Length - 1)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[i + 1].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", i + 1);
                            return;
                        }
                        if (i >= player2Cars.Length - 1)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[0].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", 0);
                            return;
                        }

                    }
                }
            }
            if (!next)
            {
                for (int i = player2Cars.Length - 1; i > -1; i--)
                {
                    if (player2Cars[i].activeSelf == true)
                    {
                        //Debug.Log(i);
                        if (i > 0)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[i - 1].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", i - 1);
                            return;
                        }
                        if (i <= 0)
                        {
                            player2Cars[i].SetActive(false);
                            player2Cars[6].SetActive(true);
                            PlayerPrefs.SetInt("Player2Car", 6);
                            return;
                        }

                    }
                }
            }
        }
    }
    void ChangeColor(bool next, int player)
    {
        if (player == 2)
        {
            //  foreach (GameObject car in player2Cars)
            //{
            if (next)
            {
                for (int j = 0; j < player2Cars.Length; j++)
                {
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (player2Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i < colors.Length - 1)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i >= colors.Length - 1)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }
            //ті хуй
            if (!next)
            {
                for (int j = player2Cars.Length-1; j > -1; j--)
                {
                    for (int i = colors.Length-1; i > -1; i--)
                    {
                        //Debug.Log(j);
                        //Debug.Log(i);
                        if (player2Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i >0)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i <= 0)
                            {
                                player2Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player2Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            //}
        }


        if (player == 1)
        {
            //  foreach (GameObject car in player2Cars)
            //{
            if (next)
            {
                for (int j = 0; j < player1Cars.Length; j++)
                {
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (player1Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i < colors.Length - 1)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i + 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i >= colors.Length - 1)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[0];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            if (!next)
            {
                for (int j = player1Cars.Length - 1; j > -1; j--)
                {
                    for (int i = colors.Length - 1; i > -1; i--)
                    {
                        //Debug.Log(j);
                        //Debug.Log(i);
                        if (player1Cars[j].GetComponentInChildren<Renderer>().sharedMaterial.color == colors[i])
                        {
                            if (i > 0)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[i - 1];
                                // PlayerPrefs.SetInt("Player1Car", i + 1);



                                return;
                            }
                            if (i <= 0)
                            {
                                player1Cars[0].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[1].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[2].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[3].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[4].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[5].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                player1Cars[6].GetComponentInChildren<Renderer>().sharedMaterial.color = colors[6];
                                // PlayerPrefs.SetInt("Player1Car", 0);
                                return;
                            }


                        }
                    }
                }
            }

            //}
        }
    }
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }
    // Update is called once per frame
    void Update () {
        pointsText.text = "YOU HAVE: " + ptsInt+" PTS";
        ptsInt = PlayerPrefs.GetInt("Points");
        if (PlayerPrefs.GetInt("Single") == 1)
        {
            foreach (GameObject car in player1Cars)
            {
                if (car.activeSelf == true)
                {
                    if (PlayerPrefs.GetInt("CarBought" + car.name) == 1)
                    {

                        Locked.SetActive(false);
                    }
                    else
                    {
                        carCost.text = "" + car.GetComponent<ColorChanger>().price + " PTS";
                        Locked.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangeCar(true,2);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangeCar(false,2);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangeColor(true, 2);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeColor(false, 2);


        if (Input.GetKeyDown(KeyCode.W))
            ChangeCar(true, 1);
        if (Input.GetKeyDown(KeyCode.S))
            ChangeCar(false, 1);
        if (Input.GetKeyDown(KeyCode.D))
            ChangeColor(true, 1);
        if (Input.GetKeyDown(KeyCode.A))
            ChangeColor(false, 1);



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
