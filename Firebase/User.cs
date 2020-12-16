using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    private string username, email;
    private int inv1, inv2, inv3, inv4;
    int token;
    public User() {}

    public User(string username, string email, int token, int inv1, int inv2, int inv3, int inv4) {
        this.username = username;
        this.email = email;
        this.token = token;
        this.inv1 = inv1;
        this.inv2 = inv2;
        this.inv3 = inv3;
        this.inv4 = inv4;

    }


}