using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject playerPrefab, followPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(playerPrefab, new Vector3 (transform.position.x, transform.position.y,0), Quaternion.identity);
        Instantiate(followPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

    }
}
