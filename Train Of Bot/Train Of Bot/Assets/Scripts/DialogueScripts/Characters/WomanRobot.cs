using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanRobot : CharacterDialogue {

    public Animator womanAnimator;
    public Animator babyAnimator;

    private void Awake()
    {
        if (DataStorage.dataStorage.womanRobotCanGive == null)
        {
            canGiveItem = true;
        }
        else
        {
            canGiveItem = DataStorage.dataStorage.womanRobotCanGive;
        }

        if (DataStorage.dataStorage.womanRobotCanRecieve == null)
        {
            canRecieveItem = true;
        }
        else
        {
            canRecieveItem = DataStorage.dataStorage.womanRobotCanRecieve;
        }
    }

    void Start()
    {
        playerInventorySlot = FindObjectOfType<PlayerController>().inventorySlot;
        if (canRecieveItem == false)
        {
            womanAnimator.Play("HappyIdle");
            babyAnimator.Play("BoyHappyIdle");
        }
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
            //if (inConversation == false)
            //{
            //    npcDialogue.npcName = "Babybot";
            //}
            dialogueParameter = 0;
            //MBMBM

        }
        else if (playerMenuNum == 1 && canRecieveItem == true)
        {
            //if (inConversation == false)
            //{
            //    npcDialogue.npcName = "Motherbot";
            //}
            dialogueParameter = 1;
            //MBMBM
        }
        else if (playerMenuNum == 2 && playerInInventory == true)
        {
            for (int i = 0; i < playerInventorySlot.Length; i++)
            {
                if (playerInventoryNum == i && playerInventorySlot[i] != (int)Items.Rattle)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        break;
                    }
                    else
                    {
                        //npcDialogue.npcName = "Motherbot";
                        dialogueParameter = 5;
                    }
                }
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.Rattle)
                {
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        //if (inConversation == false)
                        //{
                        //    npcDialogue.npcName = "Babybot";
                        //}
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveItem = false;
                        FindObjectOfType<PlayerController>().kissed = true;
                        womanAnimator.SetBool("KidHasRattle", true);
                        babyAnimator.SetBool("BoyHasRattle", true);
                        //BMBM
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
            //BM
            //if (inConversation == false)
            //{
            //    npcDialogue.npcName = "Babybot";
            //}
            dialogueParameter = 3;
        }
        else if (playerMenuNum == 1 && canRecieveItem == false)
        {
            npcDialogue.npcName = "Motherbot";
            dialogueParameter = 4;
        }
        //if (Input.GetKeyDown(KeyCode.Space) == true)
        //{
        //    SwitchNames();
        //}
    }

    //private void SwitchNames()
    //{
    //    if(npcDialogue.npcName == "Motherbot")
    //    {
    //        npcDialogue.npcName = "Babybot";
    //    }
    //    if (npcDialogue.npcName == "Babybot")
    //    {
    //        npcDialogue.npcName = "Motherbot";
    //    }
    //}

    private void OnDestroy()
    {
        DataStorage.dataStorage.womanRobotCanRecieve = canRecieveItem;
        DataStorage.dataStorage.womanRobotCanGive = canGiveItem;
    }
}