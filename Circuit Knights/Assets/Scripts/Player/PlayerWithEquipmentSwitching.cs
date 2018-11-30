////DuckBike
////Tony Le
////8 Nov 2018


//using UnityEngine;
//using CircuitKnights;
//using System.Collections.Generic;
//using System;
//using CircuitKnights.Objects;
//using CircuitKnights.Controllers;

//namespace CircuitKnights.Tests
//{
//    public class PlayerWithEquipmentSwitching : MonoBehaviour
//    {
//        //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
//        [TextArea][Multiline] string description =
//            "Sets all critical references inside the instance of Player.";
//		[SerializeField] PlayerData playerData;
//		[SerializeField] Camera camera;


//        [Header("Equipment")]

//		// [SerializeField] LanceData lanceData;
//		// [SerializeField] ShieldData shieldData;
//        // [SerializeField] HorseData horseData;

//        //Test - Weapon switching
//        [SerializeField] Equipment[] lances;
//        [SerializeField] Equipment[] shields;
//        [SerializeField] Equipment[] horses;
//        int lanceIndex = 0;
//        int shieldIndex = 0;
//        int horseIndex = 0;
//        Equipment currentLance;
//        Equipment currentShield;
//        Equipment currentHorse;


//        [Header("Controllers")]
//        [SerializeField] Horse playerMover;
//        [SerializeField] Animator playerAnimator;
//        [SerializeField] ShieldController shieldController;
//        [SerializeField] PlayerIKHoldLance IKLanceHolder;
//        [SerializeField] PlayerIKHoldShield IKShieldHolder;
//        [SerializeField] PlayerIKLook IKLook;


//        [Header("Colliders")]
//		[SerializeField] Collider headCollider;
//        [SerializeField] Collider torsoCollider;
//        [SerializeField] Collider leftArmCollider;
//        [SerializeField] Collider rightArmCollider;
//        [SerializeField] Collider shieldCollider;   //This might have to have a separate script
//        [SerializeField] Collider lanceCollider;


//        #region Properties
//        public Equipment Lance { get { return currentLance; } }
//        public Equipment Shield { get { return currentShield; } }
//        public Equipment Horse { get { return currentHorse; } }


//        public PlayerData Data { get { return playerData; } }
//        // public LanceData LanceData { get { return lanceData; } }
//        // public ShieldData ShieldData { get { return shieldData; } }
//        // public HorseData HorseData { get { return horseData; } }
//        #endregion

//        void Awake()
//        {
//            SetPlayerData();
//        }

//        private void SetPlayerData()
//        {
//            ////[IS THIS ACTUALLY NECESSARY?]
//            ////These are some of the crucial first things in the game that must be set

//            //Test - equipment switching - Set the current equipment to the first item in their arrays
//            // currentLance = lances[0];
//            // currentHorse = horses[0];
//            // currentShield = shields[0];
//            //Test

//            // playerData.LanceData = this.currentLance;
//            // playerData.ShieldData = this.shieldData;
//            // playerData.HorseData = this.horseData;

//            playerData.Root = this.transform;
//            // playerData.Camera = this.;

//            //Tricky bastard! Set both this and playerData
//            playerData.Horse = playerMover = this.GetComponent<Horse>();
//			playerData.Animator = playerAnimator;
//			// playerData.Animator = playerAnimator = this.GetComponentInChildren<Animator>();
//			playerData.ShieldController = this.shieldController = GetComponentInChildren<ShieldController>();
//            playerData.IKLanceHolder = this.IKLanceHolder = GetComponentInChildren<PlayerIKHoldLance>();
//            playerData.IKShieldHold = this.IKShieldHolder = GetComponentInChildren<PlayerIKHoldShield>();
//            playerData.IKLook = this.IKLook = GetComponentInChildren<PlayerIKLook>();
//        }

//        void Start()
//        {
//            // SetPlayerData();
//            SetPlayerColliders();
//            // MountAllEquipment();
//        }

//        void Update()
//        {
//            SwitchLances();
//            SwitchShields();
//            SwtichHorses();
//        }

//        private void SwitchLances()
//        {
//            Debug.Log("current index: " + lanceIndex);

//            //BETA RUSH
//            if (Input.GetKeyDown(KeyCode.I))
//            {
//                lanceIndex--;
//                if (lanceIndex < 0) lanceIndex = 0;
//            }
//            else if (Input.GetKeyDown(KeyCode.O))
//            {
//                lanceIndex++;
//                if (lanceIndex > lances.Length - 1) lanceIndex = lances.Length - 1;
//            }
//            //Set the lances
//            int i = 0;
//            foreach (var lance in lances)
//            {
//                if (i == lanceIndex)
//                {
//                    currentLance = lance;
//                    currentLance.Equip();
//                }
//                else
//                    lance.Unequip();

//                i++;
//            }
//        }
//        private void SwtichHorses()
//        {
//            throw new NotImplementedException();
//        }

//        private void SwitchShields()
//        {
//            throw new NotImplementedException();
//        }


//        private void SetPlayerColliders()
//        {
//            //Retrieve these after all the other scripts have set their data in their Awake()
//            playerData.HeadCollider = this.headCollider;
//            playerData.TorsoCollider = this.torsoCollider;
//            playerData.RightArmCollider = this.rightArmCollider;
//            playerData.LeftArmCollider = this.leftArmCollider;
//            playerData.ShieldCollider = this.shieldCollider;
//            playerData.LanceCollider = this.lanceCollider;
//        }

//        public void MountAllEquipment()
//        {
//            //Mount the lances
//            foreach (var lance in lances)
//            {
//                lance.Equip();
//            }
//        }

//        //Test - equipment switching
//        // void Update()
//        // {
//        //     if (Input.GetKeyDown(KeyCode.S))
//        //     {
//        //         SwitchLances();
//        //     }
//        // }
//        // public void SwitchLances()
//        // {
//        //     lanceIndex++;
//        //     if (lanceIndex >= lances.Count)
//        //         lanceIndex = 0;

//        //     if (currentLance != null)
//        //         currentLance.Unequip();

//        //     currentLance = lances[lanceIndex];
//        //     currentLance.Equip();
//        // }
//        //Test - Equipment switching
//    }
//}