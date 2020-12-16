using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TokenReward : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField]
    private int minimumTokenReward = 20;
    [SerializeField]
    private int maximumTokenReward = 50;
    public int reward;

    public int MinimumTokenReward
    {
        get { return this.minimumTokenReward; }
        set { this.minimumTokenReward = value; }
    }

    public int MaximumTokenReward
    {
        get { return this.maximumTokenReward; }
        set { this.maximumTokenReward = value; }
    }

    public int Reward()
    {
        int reward = Random.Range(this.MinimumTokenReward, this.MaximumTokenReward);
        return reward;
    }


    void update()
    {
        if(Enemy == null)
        {
            Reward();
        }
    }

}     
   
    

