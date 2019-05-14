using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenMechanicalDinner : MonoBehaviour {

    public bool taken;

    private void Awake()
    {
        try
        {
            taken = DataStorage.dataStorage.frozenMechanicalDinnerTaken;

            if (taken == true)
            {
                Destroy(gameObject);
            }
        }
        catch
        {
            return;
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.frozenMechanicalDinnerTaken = taken;
    }
}
