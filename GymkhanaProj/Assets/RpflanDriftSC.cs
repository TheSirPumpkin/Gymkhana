using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpflanDriftSC : MonoBehaviour {
    public int circleCurrent, circlesMax;
    public float MyPoints, MaxPoints;
    public Image[] Images;
    public GameObject ImageHolder;
    public Text pointsTxt;
    RCC_CarControllerV3 car;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            ImageHolder.SetActive(true);
              car = other.GetComponent<RCC_CarControllerV3>();

            if (!car.IsDrifting && circleCurrent < circlesMax)
            {
                pointsTxt.gameObject.SetActive(true);
                pointsTxt.text = "+" + MyPoints + "!!!";
                circleCurrent += 1; ResetTrigger(); foreach (Image i in Images)
                i.fillAmount = 0;
                ImageHolder.SetActive(false);
                MyPoints = 0;
            }

            if (car.IsDrifting&&circleCurrent<circlesMax)
            {

                other.GetComponent<RCC_CameraConfig>().points++;
                MyPoints++;
                 if(MyPoints< MaxPoints/3)
                { Images[0].fillAmount += Time.deltaTime / 9.8f; }
                if (MyPoints < ( (MaxPoints / 3) +  (MaxPoints / 3)) && MyPoints > MaxPoints / 3)
                { Images[1].fillAmount += Time.deltaTime / 9.8f; }
                if (MyPoints < MaxPoints && MyPoints > (MaxPoints / 3) + (MaxPoints / 3))
                { Images[2].fillAmount += Time.deltaTime / 9.8f; }


                if (MyPoints == MaxPoints / 3)
                { pointsTxt.gameObject.SetActive(true); pointsTxt.text = "+" + (MaxPoints / 3) + "!!!"; }
                if (MyPoints== ((MaxPoints / 3) + (MaxPoints / 3)))
                { pointsTxt.gameObject.SetActive(true); pointsTxt.text = "+" + ((MaxPoints / 3) + (MaxPoints / 3)) + "!!!"; }
                if (MyPoints == MaxPoints)
                { pointsTxt.gameObject.SetActive(true); pointsTxt.text = "+" + MaxPoints + "!!!"; circleCurrent+=1; ResetTrigger(); foreach (Image i in Images)
                        i.fillAmount = 0;
                    ImageHolder.SetActive(false);
                    MyPoints = 0;
                }
            }
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            pointsTxt.gameObject.SetActive(true);
           car = other.GetComponent<RCC_CarControllerV3>();
            pointsTxt.text = "+" + MyPoints + "!!!";
            if (car.IsDrifting && circleCurrent < circlesMax)
                circleCurrent += 1; ResetTrigger();
            foreach (Image i in Images)
            i.fillAmount = 0;
            ImageHolder.SetActive(false);
            MyPoints = 0;

        }
    }

    void ResetTrigger()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
      
        Invoke("EnableCollider", 5);
    }

    void EnableCollider()
    {
        circleCurrent = 0;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        
    }
}
