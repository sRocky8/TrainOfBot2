using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarmuffsGuy2 : CharacterDialogue {

    private void Awake()
    {
        try
        {
            canGiveItem = DataStorage.dataStorage.earmuffsGuyCanGive;
        }
        catch
        {
            canGiveItem = true;
        }
        Debug.Log(canRecieveItem);
        try
        {
            canRecieveItem = DataStorage.dataStorage.earmuffsGuyCanRecieve;
            Debug.Log(canRecieveItem);
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
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.Earmuffs)
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
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.Earmuffs)
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
        DataStorage.dataStorage.earmuffsGuyCanRecieve = canRecieveItem;
        DataStorage.dataStorage.earmuffsGuyCanGive = canGiveItem;
    }
}
