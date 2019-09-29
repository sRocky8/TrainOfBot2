using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : CharacterDialogue {

    private void Awake()
    {
        if (DataStorage.dataStorage.toiletcanRecieve == null)
        {
            canRecieveItem = true;
        }
        else
        {
            canRecieveItem = DataStorage.dataStorage.toiletcanRecieve;
        }
    }

    void Start()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
    }

    void Update()
    {
        if (find.GetComponent<FindPlayer>().seesPlayer == true)
        {
            CheckDialogueParam();
            TalkWithNPC();
        }
    }

    void CheckDialogueParam()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        if (playerMenuNum == 0 && canRecieveItem == true)
        {
            dialogueParameter = 0;
        }
        else if (playerMenuNum == 1 && canRecieveItem == true)
        {
            dialogueParameter = 1;
        }
        else if (playerMenuNum == 2 && playerInInventory == true)
        {
            for (int i = 0; i < playerInventorySlot.Length; i++)
            {
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.PassengersEye)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        dialogueParameter = 5;
                    }
                }
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.PassengersEye)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = (int)Items.Nothing;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[(int)Items.Nothing];
                        FindObjectOfType<PlayerController>().squeakyWheel = false;
                        canRecieveItem = false;
                        break;
                    }
                    else
                    {
                        dialogueParameter = 2;
                    }
                }
            }
        }
        else if (playerMenuNum == 0 && canRecieveItem == false)
        {
            dialogueParameter = 3;
        }
        else if (playerMenuNum == 1 && canRecieveItem == false)
        {
            dialogueParameter = 4;
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.toiletcanRecieve = canRecieveItem;
    }
}
