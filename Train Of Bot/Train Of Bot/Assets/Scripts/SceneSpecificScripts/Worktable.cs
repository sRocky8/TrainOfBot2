using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktable : CharacterDialogue {

    //COPY PASTED FROM EARMUFFS GUY CHANGE LATER

    //Public Variables
    public bool? canRecieveChefsSpoon = true;
    public bool? canRecieveBottle = true;

    public GameObject chefsSpoon;
    public GameObject bottle;
    public GameObject rattle;

    //Private Variables

    
    void Start()
    {
        canGiveItem = true;
        try
        {
            if (DataStorage.dataStorage.tableCanGiveItem != null)
            {
                canGiveItem = DataStorage.dataStorage.tableCanGiveItem;
            }
            if (DataStorage.dataStorage.canRecieveChefsSpoon != null)
            {
                canRecieveChefsSpoon = DataStorage.dataStorage.canRecieveChefsSpoon;
            }
            if (DataStorage.dataStorage.canRecieveBottle != null)
            {
                canRecieveBottle = DataStorage.dataStorage.canRecieveBottle;
            }
        }
        catch
        {
            return;
        }
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
    }

    void Update()
    {
        if (canRecieveBottle == false && canRecieveChefsSpoon == true)
        {
            bottle.SetActive(true);
        }
        if (canRecieveBottle == true && canRecieveChefsSpoon == false)
        {
            chefsSpoon.SetActive(true);
        }
        if ((canRecieveChefsSpoon == false && canRecieveBottle == false) && DataStorage.dataStorage.rattleTaken == false)
        {
            rattle.SetActive(true);
        }
        if (chefsSpoon.activeSelf == true && bottle.activeSelf == true)
        {
            chefsSpoon.SetActive(false);
            bottle.SetActive(false);
            rattle.SetActive(true);
        }
        if (find.GetComponent<FindPlayer>().seesPlayer == true)
        {
            CheckDialogueParam();
            TalkWithNPC();
        }
    }

    void CheckDialogueParam()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        if (playerMenuNum == 0 && (canRecieveChefsSpoon == true || canRecieveBottle == true))
        {
            //WORKS
            dialogueParameter = 0;
        }
        else if (playerMenuNum == 1 && (canRecieveChefsSpoon == true || canRecieveBottle == true))
        {
            //WORKS
            dialogueParameter = 1;
        }

        else if (playerMenuNum == 2 && playerInInventory == true)
        {
            for (int i = 0; i < playerInventorySlot.Length; i++)
            {
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.BottleOfBolts)
                {
                    dialogueParameter = 2;
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveBottle = false;
                        bottle.SetActive(true);
                        break;
                    }
                }

                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.ChefsSpoon)
                {
                    dialogueParameter = 2;
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveChefsSpoon = false;
                        chefsSpoon.SetActive(true);
                        break;
                    }
                }

                if (playerInventoryNum == i && (playerInventorySlot[i] != (int)Items.ChefsSpoon) && (playerInventorySlot[i] != (int)Items.BottleOfBolts))
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        //WORKS
                        dialogueParameter = 5;
                    }
                }
            }
        }

        else if (playerMenuNum == 0 && (canRecieveChefsSpoon == false && canRecieveBottle == false))
        {
            //WORKS
            dialogueParameter = 3;
        }
        else if (playerMenuNum == 1 && (canRecieveChefsSpoon == false && canRecieveBottle == false))
        {
            if (canGiveItem == true) {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //WORKS
                    dialogueParameter = 4;
                    canGiveItem = false;
                }
            }
            else
            {
                //WORKS
                dialogueParameter = 6;
            }
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.tableCanGiveItem = canGiveItem;
        DataStorage.dataStorage.canRecieveBottle = canRecieveBottle;
        DataStorage.dataStorage.canRecieveChefsSpoon = canRecieveChefsSpoon;
    }
}
