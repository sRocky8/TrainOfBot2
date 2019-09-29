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
            return;
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
                        endedDialogue = false;
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveItem = false;
                        Debug.Log("Recieved TP");
                        StartCoroutine(WaitForDialogueToFinishCoRoutine());
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

    private IEnumerator WaitForDialogueToFinishCoRoutine()
    {
        yield return new WaitUntil(() => endedDialogue == true);
        inConversation = false;
        FindObjectOfType<PlayerController>().inConversation = false;
        leftBathroom = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DataStorage.dataStorage.robotLeftBathroom = leftBathroom;
    }
}