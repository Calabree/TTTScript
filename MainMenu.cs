using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "World_Hub");
    }
    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Inventory_1()
    {
        SceneManager.LoadScene("Inventory");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void BackScene()
    {
        SceneManager.LoadScene(sceneName: "MenuScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public AudioMixer audioMixer; 
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); 
    }

    public AudioMixer HubAudioMixer;
    public void SetHubVolume(float volume)
    {
        HubAudioMixer.SetFloat("volume", volume);
    }
}
