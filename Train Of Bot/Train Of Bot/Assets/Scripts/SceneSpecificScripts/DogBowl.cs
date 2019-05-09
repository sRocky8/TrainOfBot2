using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBowl : MonoBehaviour {

    //Public Variables
    public bool hasFood = false;
    public bool dinnerActive = false;
    public GameObject cookedMechanicalDinner;
    
    //Private Variables

	
	void Start () {
        try
        {
            hasFood = DataStorage.dataStorage.bowlHasFood;
            dinnerActive = DataStorage.dataStorage.dinnerActive;
        }
        catch
        {
            return;
        }
    }
	
	void Update () {
		if(hasFood == true)
        {
            cookedMechanicalDinner.SetActive(true);
        }
	}

    private void OnDestroy()
    {
        DataStorage.dataStorage.bowlHasFood = hasFood;
        DataStorage.dataStorage.dinnerActive = dinnerActive;
    }
}
