using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomRobot : CharacterDialogue {

    public bool leftBathroom;

    private void Awake()
    {
        try
        {
            leftBathroom = DataStorage.dataStorage.robotLeftBathroom;

            if (leftBathroom == true)
            {
                Destroy(gameObject);
            }
        }
        catch
        {
            leftBathroom = false;
        }
    }

    void Start()
    {
        canRecieveItem = true;
        canGiveItem = true;
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
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.TP)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        dialogueParameter = 3;
                    }
                }
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.TP)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        dialogueParameter = 2;
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.robotLeftBathroom = leftBathroom;
    }
}