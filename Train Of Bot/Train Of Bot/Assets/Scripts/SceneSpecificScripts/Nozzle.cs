using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nozzle : CharacterDialogue {

    public GameObject valve;

    private void Awake()
    {
        if (DataStorage.dataStorage.nozzleCanRecieve == null)
        {
            canRecieveItem = true;
        }
        else
        {
            canRecieveItem = DataStorage.dataStorage.nozzleCanRecieve;
        }
    }

    void Start()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
    }

    void Update()
    {
        if(canRecieveItem == false)
        {
            valve.SetActive(true);
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
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.Valve)
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
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.Valve)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
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
        DataStorage.dataStorage.nozzleCanRecieve = canRecieveItem;
    }
}
