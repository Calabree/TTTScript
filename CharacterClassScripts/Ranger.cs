using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger:MonoBehaviour
{
    public CharacterStats Health;
    public CharacterStats Stregnth;
    public CharacterStats Magic;
    public CharacterStats Dex;
    public CharacterStats Def;
    public CharacterStats Resistance;
    public CharacterStats Speed;

    private void Start()
    {
        Health.BaseValue = 100f;
        Stregnth.BaseValue = 0f;
        Magic.BaseValue = 30f;
        Dex.BaseValue = 30f;
        Def.BaseValue = 5f;
        Resistance.BaseValue = 5f;
        Speed.BaseValue = 10f;
    }



}
    