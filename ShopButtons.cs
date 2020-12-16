using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Text Textfield;
    public Text Textfield2;
    public Text Textfield3;
    public void SetText1(string text)
    {
        Textfield.text = text;
    }
    public void SetText2(string text)
    {
        Textfield2.text = text;
    }

    public void SetText3(string text)
    {
        Textfield3.text = text;
    }



}
