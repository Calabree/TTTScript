
using UnityEngine;

public class TokenConverter
{
    private Pedometer pedometer;
    private string key;
    private int steps, token;
  

    public TokenConverter()
    {
        pedometer = new Pedometer();
    }

    public void calculateTokens(int token)
    {
        this.token = token;
        setSteps();
        this.token += steps;
     
    }

    public int getTokens()
    {
        return token;
    }

    private void setSteps()
    {
        steps = pedometer.GetSteps();
    }

    
}
