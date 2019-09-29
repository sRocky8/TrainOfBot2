using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Collider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(DataStorage.dataStorage.nozzleCanRecieve == false)
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Light>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Light>().enabled = false;
        }
	}
}
