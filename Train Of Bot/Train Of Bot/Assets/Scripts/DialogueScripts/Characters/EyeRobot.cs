using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRobot : CharacterDialogue {

    //COPY PASTED FROM EARMUFFS GUY CHANGE LATER
    private void Awake()
    {
        try
        {
            canGiveItem = DataStorage.dataStorage.eyeRobotCanGive;
        }
        catch
        {
            canGiveItem = true;
        }

        try
        {
            canRecieveItem = DataStorage.dataStorage.eyeRobotCanRecieve;
        }
        catch
        {
            canRecieveItem = true;
        }
    }

    void Start()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
    }

    void Update()
    {
        CheckDialogueParam();
        TalkWithNPC();
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
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.Plunger)
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
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.Plunger)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        dialogueParameter = 2;
                        canRecieveItem = false;
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
        DataStorage.dataStorage.eyeRobotCanRecieve = canRecieveItem;
        DataStorage.dataStorage.eyeRobotCanGive = canGiveItem;
    }

}
