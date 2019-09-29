using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour {

    public bool taken = false;
    public bool thrown = false;
    public Vector3 robotHand;
    public Vector3 wallStick;

    public float lerpPosition;
    public float translationValue;

    private void Awake()
    {
        try
        {
            taken = DataStorage.dataStorage.plungerTaken;
            thrown = DataStorage.dataStorage.plungerThrown;

            if (taken == true)
            {
                Destroy(gameObject);
            }
            if (thrown == true)
            {
                transform.position = wallStick;
            }
        }
        catch
        {
            return;
        }
    }

    private void Update()
    {
        if(thrown == false)
        {
            if (lerpPosition < 1.0f)
            {
                transform.position = Vector3.Lerp(robotHand, wallStick, lerpPosition);
                lerpPosition += 1.0f / translationValue;
            }
            else if (lerpPosition >= 1.0f)
            {
                thrown = true;
            }
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.plungerTaken = taken;
        DataStorage.dataStorage.plungerThrown = thrown;
    }
}
