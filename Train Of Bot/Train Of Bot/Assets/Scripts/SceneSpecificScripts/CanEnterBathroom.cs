using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEnterBathroom : MonoBehaviour {

	void Start () {

    }

	void Update () {
        if (DataStorage.dataStorage.robotLeftBathroom == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            Destroy(this);
        }
    }
}
