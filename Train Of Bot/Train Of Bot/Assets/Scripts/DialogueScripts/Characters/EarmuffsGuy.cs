using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarmuffsGuy : CharacterDialogue {

    public GameObject earmuffs;

    private Animator animator;

    private void Awake()
    {
        if (DataStorage.dataStorage.earmuffsGuyCanGive == null)
        {
            canGiveItem = true;
        }
        else
        {
            canGiveItem = DataStorage.dataStorage.earmuffsGuyCanGive;
        }

        if (DataStorage.dataStorage.earmuffsGuyCanRecieve == null)
        {
            canRecieveItem = true;
        }
        else
        {
            canRecieveItem = DataStorage.dataStorage.earmuffsGuyCanRecieve;
        }
    }

    void Start () {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        animator = GetComponent<Animator>();
        if (canRecieveItem == false)
        {
            animator.Play("HappyIdle");
            earmuffs.SetActive(true);
        }
    }
	
	void Update () {
        if (find.GetComponent<FindPlayer>().seesPlayer == true) {
            CheckDialogueParam();
            TalkWithNPC();
        }
	}

    void CheckDialogueParam()
    {
        Debug.Log(playerMenuNum);
        Debug.Log(canRecieveItem);
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
                        FindObjectOfType<PlayerController>().inventorySlot[i] = (int)Items.TP;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[(int)Items.TP];
                        canRecieveItem = false;
                        animator.SetBool("RecievedEarmuffs", true);
                        earmuffs.SetActive(true);
                        Debug.Log("Recieved Earmuffs, Gave TP");
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