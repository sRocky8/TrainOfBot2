using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    //Public Variables
    public bool eating = false;


    //Private Variables
    private Animator dogAnimator;

    
    void Start()
    {
        try
        {
            transform.position = DataStorage.dataStorage.dogLocation;
            eating = DataStorage.dataStorage.dogEating;
        }
        catch
        {
            return;
        }
        dogAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (eating == true)
        {
            DataStorage.dataStorage.dogLocation = transform.position;
            DataStorage.dataStorage.dogEating = eating;
            dogAnimator.Play("Eat");
        }
        else
        {
            return;
        }
    }


}

