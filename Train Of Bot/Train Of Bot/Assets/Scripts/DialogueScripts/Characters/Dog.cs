using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    //Public Variables
    public bool eating;
    public bool goingToEat = false;
    public bool moving = false;
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float lerpPosition;
    public float translationValue;
    public float timeUntilStartMoving;
    public float timeUntilStopMoving;
    public GameObject toEngine;

    //Private Variables
    private Animator dogAnimator;


    void Start()
    {
        try
        {
            if (DataStorage.dataStorage.dogLocation != Vector3.zero)
            {
                transform.position = DataStorage.dataStorage.dogLocation;
                eating = DataStorage.dataStorage.dogEating;
            }
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
            toEngine.SetActive(true);
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
        goingToEat = false;
        FindObjectOfType<PlayerController>().stopPlayer = true;
        dogAnimator.SetBool("FoodInBowl", true);
        //dogAnimator.Play("GetUp");
        yield return new WaitForSeconds(timeUntilStartMoving);
        moving = true;
        yield return new WaitForSeconds(timeUntilStopMoving);
        moving = false;
        eating = true;
        FindObjectOfType<PlayerController>().stopPlayer = false;
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.dogLocation = transform.position;
        DataStorage.dataStorage.dogEating = eating;
    }
}

