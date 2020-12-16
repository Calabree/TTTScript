using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior:MonoBehaviour
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
        Health.BaseValue = 125f;
        Stregnth.BaseValue = 25f;
        Magic.BaseValue = 0;
        Dex.BaseValue = 0f;
        Def.BaseValue = 10f;
        Resistance.BaseValue = 0f;
        Speed.BaseValue = 3f;
    }



}
    