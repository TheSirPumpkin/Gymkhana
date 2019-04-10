using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundControl : MonoBehaviour {
    public bool SoundOn, SoundOff;
    Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
	}

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale!=0)
        AudioListener.volume = PlayerPrefs.GetInt("Sound");
        if (Time.timeScale == 0)
            AudioListener.volume =0;
        if (PlayerPrefs.GetInt("Sound") == 0 && SoundOn)
        {
            btn.interactable = true;
            btn.GetComponent<Image>().enabled = true;
        }
        if (PlayerPrefs.GetInt("Sound") == 0 && SoundOff)
        {
            btn.interactable = false;
            btn.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("Sound") == 1 && SoundOn)
        {
            btn.interactable = false;
            btn.GetComponent<Image>().enabled = false;
        }
        if (PlayerPrefs.GetInt("Sound") == 1 && SoundOff)
        {
            btn.GetComponent<Image>().enabled = true;
            btn.interactable = true;
        }

    }
    public void Sound(int i)
    {
        PlayerPrefs.SetInt("Sound", i);
    }
}
