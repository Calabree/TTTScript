using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager man;

    public GameObject loginUI;
    public GameObject registerUI;

    private void Awake()
    {
        if (man == null)
        {
            man = this;
        }
        else if (man != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void LoginScreen() // Login Button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }

    public void RegisterScreen() // Register button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }
}
