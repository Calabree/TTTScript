using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pedometer : MonoBehaviour
{
    [Header("UI")]
    //public Text stepsText;

    [Header("Pedometer")]
    public float lowLimit = 0.005F; // Level to fall to the low state. 
    public float highLimit = 0.1F; // Level to go to high state (and detect steps).
    private bool stateHigh = false; // Comparator state.

    public float filterHigh = 10.0F; // Noise filter control. Reduces frequencies above filterHigh private . 
    public float filterLow = 0.1F; // Average gravity filter control. Time constant about 1/filterLow.
    public float currentAcceleration = 0F; // Noise filter.
    float averageAcceleration = 0F;

    public static int steps = 0; // Step counter. Counts when comparator state goes to high.
    private int oldSteps;
    public float waitCounter = 0F;
    public bool isWalking = false;
    private bool startWaitCounter = false;

    void Awake()
    {
        averageAcceleration = Input.acceleration.magnitude; // Initialize average filter.
        oldSteps = steps;
    }

    void Update()
    {
        
        WalkingCheck(); // Checks if you are walking or not.
    }

    public int GetSteps()
    {
        return steps;
    }

    public void ResetSteps()
    {
        steps = 0;
    }
    void FixedUpdate()
    { 
        // Filter Input.acceleration using Math.Lerp.
        currentAcceleration = Mathf.Lerp(currentAcceleration, Input.acceleration.magnitude, Time.deltaTime * filterHigh);
        averageAcceleration = Mathf.Lerp(averageAcceleration, Input.acceleration.magnitude, Time.deltaTime * filterLow);

        float delta = currentAcceleration - averageAcceleration; // Gets the acceleration pulses.

        if (!stateHigh)
        { 
            // If the state is low.
            if (delta > highLimit)
            { 
                // Only goes to high, if the Input is higher than the highLimit.
                stateHigh = true;
                steps++; // Counts the steps when the comparator goes to high.
                //stepsText.text = steps.ToString();
            }
        }
        else
        {
            if (delta < lowLimit)
            { 
                // Only goes to low, if the Input is lower than the lowLimit.
                stateHigh = false;
            }
        }
    }

    // Checks if you are walking or not.
    private void WalkingCheck()
    {
        if (steps != oldSteps)
        {
            startWaitCounter = true;
            waitCounter = 0F;
        }

        if (startWaitCounter)
        {
            waitCounter += Time.deltaTime;

            if (waitCounter != 0)
            {
                isWalking = true;
            }
            if (waitCounter > 2.5)
            {
                waitCounter = 0F;
                startWaitCounter = false;
            }
        }
        else if (!startWaitCounter)
        {
            isWalking = false;
        }
        oldSteps = steps;
    }
}
