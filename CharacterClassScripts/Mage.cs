using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage:MonoBehaviour
{
    public CharacterStats Health;
    public CharacterStats Stregnth;
    public CharacterStats Magic;
    public CharacterStats Dex;
    public CharacterStats Def;
    public CharacterStats Resistance;
    public CharacterStats Speed;
    [SerializeField] GameObject Ded;
    private bool isON = false;
   

    private void Start()
    {
        if (GameObject.Find("Ded"))
        {
            Ded = GameObject.Find("Ded");
            Ded.SetActive(false);
        }
        Health.BaseValue = 75f;
        Stregnth.BaseValue = 0f;
        Magic.BaseValue = 30f;
        Dex.BaseValue = 0f;
        Def.BaseValue = 5f;
        Resistance.BaseValue = 10f;
        Speed.BaseValue = 5f;
    }

    public void takeDamage(float damage)
    {
        Health.BaseValue -= damage;
        if (Health.BaseValue <= 0f)
        {
            Die();
        }
    }   
    void Die()
    {
        Debug.Log("Dead");
        
        Destroy(this.gameObject);
        
        if (isON == false)
        {
            Ded.SetActive(true);
        }

    }

}

