using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataStorage : MonoBehaviour {

    public static DataStorage dataStorage;

    public float testFloat;
    public Vector3 storageRoomBoxPos;
    public bool? testCharacterCanRecieve;
    public bool? testCharacterCanGive;

    //HAS STUFF BEEN TAKEN?
    public bool bottleOfBoltsTaken;
    public bool cabinetKeyTaken;
    public bool chefsSpoonTaken;
    public bool cookedMechanicalDinnerTaken;
    public bool earmuffsTaken;
    public bool frozenMechanicalDinnerTaken;
    public bool gasCanisterTaken;
    public bool passengersEyeTaken;
    public bool plungerTaken;
    public bool rattleTaken;
    public bool valveTaken;

    public bool plungerThrown;

    //NPCS
    public bool? earmuffsGuyCanGive;
    public bool? earmuffsGuyCanRecieve;

    public bool? eyeRobotCanGive;
    public bool? eyeRobotCanRecieve;

    public bool? chefCanGive;
    public bool? chefCanRecieve;
    public bool? chefFrozen;

    public bool? womanRobotCanGive;
    public bool? womanRobotCanRecieve;

    public bool? cabinetCanGive;
    public bool? cabinetCanRecieve;

    public bool? toiletcanRecieve;

    public bool? hoboThrew;

    public bool? nozzleCanRecieve;

    //ROBOT SPECIFIC
    public bool robotLeftBathroom;

    //DOG
    public bool dogEating;
    public Vector3 dogLocation;

    //DOG BOWL
    public bool bowlHasFood;
    public bool dinnerActive;

    //WORKTABLE
    public bool? canRecieveChefsSpoon;
    public bool? canRecieveBottle;
    public bool? tableCanGiveItem;

    //STOVE
    public bool? canRecieveFMD;
    public bool? canRecieveGasCanister;
    public bool? stoveCanGiveItem;

    private void Awake()
    {
        if (dataStorage == null)
        {
            DontDestroyOnLoad(gameObject);
            dataStorage = this;
        }
        else if(dataStorage != null)
        {
            Destroy(gameObject);
        }
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(10, 10, 100, 80), "test float: " + testFloat);
    //}

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream dataFile = File.Create(Application.persistentDataPath + "/TrainOfBotDataFile.dat");

        Data data = new Data();
        data.testFloat = 0.0f;
        data.storageRoomBoxPos = StorageRoomBox.FindObjectOfType<Transform>().position;
        data.testCharacterCanRecieve = true;
        data.testCharacterCanGive = true;

        //ITEMS
        data.bottleOfBoltsTaken = BottleOfBolts.FindObjectOfType<BottleOfBolts>().taken;
        data.cabinetKeyTaken = CabinetKey.FindObjectOfType<CabinetKey>().taken;
        data.chefsSpoonTaken = ChefsSpoon.FindObjectOfType<ChefsSpoon>().taken;
        data.cookedMechanicalDinnerTaken = CookedMechanicalDinner.FindObjectOfType<CookedMechanicalDinner>().taken;
        data.earmuffsTaken = Earmuffs.FindObjectOfType<Earmuffs>().taken;
        data.frozenMechanicalDinnerTaken = FrozenMechanicalDinner.FindObjectOfType<FrozenMechanicalDinner>().taken;
        data.gasCanisterTaken = GasCanister.FindObjectOfType<GasCanister>().taken;
        data.passengersEyeTaken = PassengersEye.FindObjectOfType<PassengersEye>().taken;
        data.plungerTaken = Plunger.FindObjectOfType<Plunger>().taken;
        data.rattleTaken = Rattle.FindObjectOfType<Rattle>().taken;
        data.valveTaken = Valve.FindObjectOfType<Valve>().taken;

        data.plungerThrown = Plunger.FindObjectOfType<Plunger>().thrown;

        //NPCS
        data.earmuffsGuyCanGive = EarmuffsGuy.FindObjectOfType<EarmuffsGuy>().canGiveItem;
        data.earmuffsGuyCanRecieve = EarmuffsGuy.FindObjectOfType<EarmuffsGuy>().canRecieveItem;

        data.eyeRobotCanGive = EyeRobot.FindObjectOfType<EyeRobot>().canGiveItem;
        data.eyeRobotCanRecieve = EyeRobot.FindObjectOfType<EyeRobot>().canRecieveItem;

        data.chefCanGive = Chef.FindObjectOfType<Chef>().canGiveItem;
        data.chefCanRecieve = Chef.FindObjectOfType<Chef>().canRecieveItem;
        data.chefFrozen = Chef.FindObjectOfType<Chef>().frozen;

        data.womanRobotCanGive = WomanRobot.FindObjectOfType<WomanRobot>().canGiveItem;
        data.womanRobotCanRecieve = WomanRobot.FindObjectOfType<WomanRobot>().canRecieveItem;

        data.cabinetCanGive = Cabinet.FindObjectOfType<Cabinet>().canGiveItem;
        data.cabinetCanRecieve = Cabinet.FindObjectOfType<Cabinet>().canRecieveItem;

        data.toiletcanRecieve = Toilet.FindObjectOfType<Toilet>().canRecieveItem;

        data.hoboThrew = HoboRobot.FindObjectOfType<HoboRobot>().hoboThrew;

        data.nozzleCanRecieve = Nozzle.FindObjectOfType<Nozzle>().canRecieveItem;

        //ROBOT SPECIFIC
        data.robotLeftBathroom = BathroomRobot.FindObjectOfType<BathroomRobot>().leftBathroom;

        //DOG
        data.dogEating = Dog.FindObjectOfType<Dog>().eating;
        data.dogLocation = Dog.FindObjectOfType<Transform>().position;

        //DOG BOWL
        data.bowlHasFood = DogBowl.FindObjectOfType<DogBowl>().hasFood;
        data.dinnerActive = DogBowl.FindObjectOfType<DogBowl>().dinnerActive;

        //WORKTABLE
        data.canRecieveChefsSpoon = Worktable.FindObjectOfType<Worktable>().canRecieveChefsSpoon;
        data.canRecieveBottle = Worktable.FindObjectOfType<Worktable>().canRecieveBottle;
        data.tableCanGiveItem = Worktable.FindObjectOfType<Worktable>().canGiveItem;

        //STOVE
        data.canRecieveFMD = Stove.FindObjectOfType<Stove>().canRecieveFMD;
        data.canRecieveGasCanister = Stove.FindObjectOfType<Stove>().canRecieveGasCanister;
        data.stoveCanGiveItem = Stove.FindObjectOfType<Stove>().canGiveItem;

        //        Data data = new Data
        //        {
        //            testFloat = 0.0f
        //        };

        binaryFormatter.Serialize(dataFile, data);
        dataFile.Close();
    }

    public void Load()
    {

        if (File.Exists(Application.persistentDataPath + "/TrainOfBotDataFile.dat")) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream dataFile = File.Open(Application.persistentDataPath + "/TrainOfBotDataFile.dat", FileMode.Open);
            Data data = (Data)binaryFormatter.Deserialize(dataFile);
            dataFile.Close();

            testFloat = data.testFloat;
            storageRoomBoxPos = data.storageRoomBoxPos;
            testCharacterCanRecieve = data.testCharacterCanRecieve;
            testCharacterCanGive = data.testCharacterCanGive;

            //HAS STUFF BEEN TAKEN?
            bottleOfBoltsTaken = data.bottleOfBoltsTaken;
            cabinetKeyTaken = data.cabinetKeyTaken;
            chefsSpoonTaken = data.chefsSpoonTaken;
            cookedMechanicalDinnerTaken = data.cookedMechanicalDinnerTaken;
            earmuffsTaken = data.earmuffsTaken;
            frozenMechanicalDinnerTaken = data.frozenMechanicalDinnerTaken;
            gasCanisterTaken = data.gasCanisterTaken;
            passengersEyeTaken = data.passengersEyeTaken;
            plungerTaken = data.plungerTaken;
            rattleTaken = data.rattleTaken;
            valveTaken = data.valveTaken;

            plungerThrown = data.plungerThrown;

            //NPCS
            earmuffsGuyCanGive = data.earmuffsGuyCanGive;
            earmuffsGuyCanRecieve = data.earmuffsGuyCanRecieve;

            eyeRobotCanGive = data.eyeRobotCanGive;
            eyeRobotCanRecieve = data.eyeRobotCanRecieve;

            chefCanGive = data.chefCanGive;
            chefCanRecieve = data.chefCanRecieve;
            chefFrozen = data.chefFrozen;

            womanRobotCanGive = data.womanRobotCanGive;
            womanRobotCanRecieve = data.womanRobotCanRecieve;

            cabinetCanGive = data.cabinetCanGive;
            cabinetCanRecieve = data.cabinetCanRecieve;

            toiletcanRecieve = data.toiletcanRecieve;

            hoboThrew = data.hoboThrew;

            nozzleCanRecieve = data.nozzleCanRecieve;

            //CHARACTER SPECIFIC
            robotLeftBathroom = data.robotLeftBathroom;

            //DOG
            dogEating = data.dogEating;
            dogLocation = data.dogLocation;

            //DOG BOWL
            bowlHasFood = data.bowlHasFood;
            dinnerActive = data.dinnerActive;

            //WORKTABLE
            canRecieveBottle = data.canRecieveBottle;
            canRecieveChefsSpoon = data.canRecieveChefsSpoon;
            tableCanGiveItem = data.tableCanGiveItem;

            //STOVE
            canRecieveFMD = data.canRecieveFMD;
            canRecieveGasCanister = data.canRecieveGasCanister;
            stoveCanGiveItem = data.stoveCanGiveItem;
        }
    }

    [Serializable]
    class Data
    {
        //TESTING
        public float testFloat;
        public bool? testCharacterCanRecieve;
        public bool? testCharacterCanGive;

        //MISC OBJECTS
        public Vector3 storageRoomBoxPos;

        //HAS STUFF BEEN TAKEN?
        public bool bottleOfBoltsTaken;
        public bool cabinetKeyTaken;
        public bool chefsSpoonTaken;
        public bool cookedMechanicalDinnerTaken;
        public bool earmuffsTaken;
        public bool frozenMechanicalDinnerTaken;
        public bool gasCanisterTaken;
        public bool passengersEyeTaken;
        public bool plungerTaken;
        public bool rattleTaken;
        public bool valveTaken;

        public bool plungerThrown;

        //NPCS
        public bool? earmuffsGuyCanGive;
        public bool? earmuffsGuyCanRecieve;

        public bool? eyeRobotCanGive;
        public bool? eyeRobotCanRecieve;

        public bool? chefCanGive;
        public bool? chefCanRecieve;
        public bool? chefFrozen;

        public bool? womanRobotCanGive;
        public bool? womanRobotCanRecieve;

        public bool? cabinetCanGive;
        public bool? cabinetCanRecieve;

        public bool? toiletcanRecieve;

        public bool? hoboThrew;

        public bool? nozzleCanRecieve;

        //CHARACTER SPECIFIC
        public bool robotLeftBathroom;

        //DOG
        public bool dogEating;
        public Vector3 dogLocation;

        //DOG BOWL
        public bool bowlHasFood;
        public bool dinnerActive;

        //WORKTABLE
        public bool? canRecieveChefsSpoon;
        public bool? canRecieveBottle;
        public bool? tableCanGiveItem;

        //STOVE
        public bool? canRecieveFMD;
        public bool? canRecieveGasCanister;
        public bool? stoveCanGiveItem;
    }
}
