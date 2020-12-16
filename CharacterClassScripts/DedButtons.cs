using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DedButtons : MonoBehaviour
{
    public void MountainMama()
    {
        SceneManager.LoadScene(sceneName: "World_Hub");
    }

    public void sceneRestart()
    {
        SceneManager.LoadScene(sceneName: "BattleScene1");
    }
}
