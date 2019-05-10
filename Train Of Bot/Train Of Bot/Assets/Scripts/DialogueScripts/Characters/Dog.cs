using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    //Public Variables
    public bool eating = false;
    public bool goingToEat = false;
    public bool moving = false;
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float lerpPosition;
    public float translationValue;

    //Private Variables
    private Animator dogAnimator;
    private bool onTheWay;


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
            if (FindObjectOfType<DogBowl>().hasFood == true)
            {
                goingToEat = true;
            }
            if (goingToEat == true)
            {
                StartCoroutine(WalkToFoodCoRoutine());
            }
            if (moving == true)
            {
                transform.position = Vector3.Lerp(startingPosition, endingPosition, lerpPosition);
                lerpPosition += 1.0f / translationValue;
            }
        }
    }

    private IEnumerator WalkToFoodCoRoutine()
    {
        FindObjectOfType<PlayerController>().stopPlayer = true;
        dogAnimator.Play("GetUp");
        yield return new WaitForSeconds(0.983f);
        moving = true;
        yield return new WaitForSeconds(1.834f);
        moving = false;
        eating = true;
        FindObjectOfType<PlayerController>().stopPlayer = false;
    }
}

