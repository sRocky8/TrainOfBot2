using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : CharacterDialogue {

    //Public Variables
    public bool? canRecieveFMD = true;
    public bool? canRecieveGasCanister = true;

    public GameObject frozenMechanicalDinner;
    public GameObject gasCanister;
    public GameObject cookedMechanicalDinner;

    //Private Variables


    void Start()
    {
        canGiveItem = true;
        try
        {
            if (DataStorage.dataStorage.stoveCanGiveItem != null)
            {
                canGiveItem = DataStorage.dataStorage.stoveCanGiveItem;
            }
            if (DataStorage.dataStorage.canRecieveFMD != null)
            {
                canRecieveFMD = DataStorage.dataStorage.canRecieveFMD;
            }
            if (DataStorage.dataStorage.canRecieveGasCanister != null)
            {
                canRecieveGasCanister = DataStorage.dataStorage.canRecieveGasCanister;
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
        if (canRecieveFMD == false && canRecieveGasCanister == true)
        {
            frozenMechanicalDinner.SetActive(true);
        }
        if (canRecieveFMD == true && canRecieveGasCanister == false)
        {
            gasCanister.SetActive(true);
        }
        if ((canRecieveFMD == false && canRecieveGasCanister == false) && DataStorage.dataStorage.cookedMechanicalDinnerTaken == false)
        {
            cookedMechanicalDinner.SetActive(true);
        }
        if (frozenMechanicalDinner.activeSelf == true && gasCanister.activeSelf == true)
        {
            frozenMechanicalDinner.SetActive(false);
            gasCanister.SetActive(false);
            cookedMechanicalDinner.SetActive(true);
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
        if (playerMenuNum == 0 && (canRecieveFMD == true || canRecieveGasCanister == true))
        {
            //WORKS
            dialogueParameter = 0;
        }
        else if (playerMenuNum == 1 && (canRecieveFMD == true || canRecieveGasCanister == true))
        {
            //WORKS
            dialogueParameter = 1;
        }

        else if (playerMenuNum == 2 && playerInInventory == true)
        {
            for (int i = 0; i < playerInventorySlot.Length; i++)
            {
                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.GasCanister)
                {
                    dialogueParameter = 2;
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveGasCanister = false;
                        gasCanister.SetActive(true);
                        break;
                    }
                }

                if (playerInventoryNum == i && playerInventorySlot[i] == (int)Items.FrozenMechanicalDinner)
                {
                    dialogueParameter = 2;
                    if (Input.GetKeyDown(KeyCode.Space) == true)
                    {
                        FindObjectOfType<PlayerController>().inventorySlot[i] = 0;
                        FindObjectOfType<PlayerController>().inventory[i].sprite = FindObjectOfType<PlayerController>().inventoryImage[0];
                        canRecieveFMD = false;
                        frozenMechanicalDinner.SetActive(true);
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

        else if (playerMenuNum == 0 && (canRecieveFMD == false && canRecieveGasCanister == false))
        {
            //WORKS
            dialogueParameter = 3;
        }
        else if (playerMenuNum == 1 && (canRecieveFMD == false && canRecieveGasCanister == false))
        {
            if (canGiveItem == true)
            {
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
        DataStorage.dataStorage.stoveCanGiveItem = canGiveItem;
        DataStorage.dataStorage.canRecieveFMD = canRecieveFMD;
        DataStorage.dataStorage.canRecieveGasCanister = canRecieveGasCanister;
    }
}
