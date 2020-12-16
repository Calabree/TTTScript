using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroON : MonoBehaviour
{
    public GameObject HeroUI;
    public bool isON = false;

    public void HeroONOFF()
    {
        if(isON == true)
        {
            HeroUI.SetActive(true);
            isON = !isON;
        }
       else if(isON == false)
        {
            HeroUI.SetActive(false);
            isON = !isON;
        }
        
       
    }
}
