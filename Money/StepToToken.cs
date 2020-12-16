using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StepToToken : MonoBehaviour
{
    public int TipToeTokens = 5000;
    private int steps;
    [SerializeField] TextMeshProUGUI TokenDisp;

    void start()
    {
        TipToeTokens = PlayerPrefs.GetInt("TipToe Tokens");
    }

    private int setTokens()
    {
        TipToeTokens = TipToeTokens + steps;
        PlayerPrefs.SetInt("TipToe Tokens", TipToeTokens);
        return TipToeTokens;
    }

    //private void getToken() => steps = Pedometer.GetSteps();


    void LateUpdate()
    {
        
        setTokens();
        TokenDisp.text = TipToeTokens.ToString();

    }
}

