using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {

    //Public Variables
    [HideInInspector] public bool seesPlayer;

    //Private Variables

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            seesPlayer = true;
        }
        else if (other.tag == null)
        {
            seesPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == null)
        {
            seesPlayer = false;
        }
    }
}
