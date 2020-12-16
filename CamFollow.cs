using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    private GameObject player;

    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(.01f); // allows character to spawn in
        player = GameObject.FindGameObjectWithTag("Player"); // Looks for player tag
    }
    void FixedUpdate()
    {
        try
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
        } catch(NullReferenceException e)
        {

        }
        
    }
}   