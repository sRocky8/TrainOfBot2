using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEnterEngineRoom : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        if (FindObjectOfType<Dog>().eating == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
	}
}
