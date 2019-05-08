using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBowl : MonoBehaviour {

    //Public Variables
    public bool hasFood = false;
    
    //Private Variables

	
	void Start () {
        try
        {
            hasFood = DataStorage.dataStorage.bowlHasFood;
        }
        catch
        {
            return;
        }
    }
	
	void Update () {
		if(hasFood == true)
        {

        }
	}

    private void OnDestroy()
    {
        DataStorage.dataStorage.bowlHasFood = hasFood;
    }
}
