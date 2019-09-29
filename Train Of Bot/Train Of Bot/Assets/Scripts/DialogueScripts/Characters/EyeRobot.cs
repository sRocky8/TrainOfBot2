using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRobot : CharacterDialogue {

    private Animator animator;

    private void Awake()
    {
        if (DataStorage.dataStorage.eyeRobotCanGive == null)
        {
            canGiveItem = true;
        }
        else
        {
            canGiveItem = DataStorage.dataStorage.eyeRobotCanGive;
        }

        if (DataStorage.dataStorage.eyeRobotCanRecieve == null)
        {
            canRecieveItem = true;
        }
        else
        {
            canRecieveItem = DataStorage.dataStorage.eyeRobotCanRecieve;
        }
    }

    void Start()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        animator = GetComponent<Animator>();
        if (canRecieveItem == false)
        {
            animator.Play("HappyIdle");
        }
    }

    void Update()
    {
        if (find.GetComponent<FindPlayer>().seesPlayer == true) {
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
                        FindObjectOfType<PlayerController>().inventorySlot[i] = (int)Items.PassengersEye;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[(int)Items.PassengersEye];
                        canRecieveItem = false;
                        animator.SetBool("LostEye", true);
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
        DataStorage.dataStorage.eyeRobotCanRecieve = canRecieveItem;
        DataStorage.dataStorage.eyeRobotCanGive = canGiveItem;
    }

}
