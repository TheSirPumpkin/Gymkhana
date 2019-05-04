using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpflanDriftSC : MonoBehaviour {
    public float MyPoints, MaxPoints;
    public Image[] Images;
    public GameObject ImageHolder;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            ImageHolder.SetActive(true);
               RCC_CarControllerV3 car = other.GetComponent<RCC_CarControllerV3>();
            if (car.IsDrifting)
            {

                other.GetComponent<RCC_CameraConfig>().points++;
                MyPoints++;
                    if(MyPoints< MaxPoints/3)
                { Images[0].fillAmount += Time.deltaTime / 20; }
                    if (MyPoints < MaxPoints / 2 &&MyPoints > MaxPoints / 3)
                { Images[1].fillAmount += Time.deltaTime / 20; }
                        if (MyPoints < MaxPoints && MyPoints > MaxPoints / 2)
                { Images[2].fillAmount += Time.deltaTime / 20; }
            }
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {foreach (Image i in Images)
                i.fillAmount = 0;
            ImageHolder.SetActive(false);
            MyPoints = 0;

        }
    }
}
