using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpflanDriftSC : MonoBehaviour {
    public GameObject DonutCounter;
    public Image[] DonutUIElements;
    public float maxPoints, maxPointsStart;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            DonutCounter.SetActive(true);
               RCC_CarControllerV3 car = other.GetComponent<RCC_CarControllerV3>();
            if (car.IsDrifting)
            {
                other.GetComponent<RCC_CameraConfig>().points++;
                maxPoints++;
                if (maxPoints < maxPointsStart / 3)
                {
                    DonutUIElements[0].fillAmount += Time.deltaTime/20;
                }
                if (maxPoints < maxPointsStart / 2&& maxPoints> maxPointsStart / 3)
                {
                    
                    DonutUIElements[1].fillAmount += Time.deltaTime / 20;
                }
                if (maxPoints < maxPointsStart&& maxPoints > maxPointsStart / 2)
                {
                    DonutUIElements[2].fillAmount += Time.deltaTime / 20;
                }
            }
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            foreach (Image i in DonutUIElements)
                i.fillAmount = 0;
            DonutCounter.SetActive(false);
           

        }
    }
}
