//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;
using CircuitKnights;
using System.Collections.Generic;

namespace CircuitKnights.Objects
{
    public class Player : MonoBehaviour
    {
        //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
        [TextArea][Multiline] string description =
            "Sets all critical references inside the instance of Player.";
		[SerializeField] PlayerData playerData;
		[SerializeField] new Camera camera;


        [Header("Equipment")]

		[SerializeField] LanceData lanceData;
		[SerializeField] ShieldData shieldData;
        [SerializeField] HorseData horseData;
        
        PlayerMover playerMover;

        // //Test - Weapon switching
        // [SerializeField] List<Equipment> lances;
        // [SerializeField] List<Equipment> shields;
        // [SerializeField] List<Equipment> horses;
        // int lanceIndex = 0;
        // int shieldIndex = 0;
        // int horseIndex = 0;
        // Equipment currentLance;
        // Equipment currentShield;
        // Equipment currentHorse;
        //Test - weapon switching



        [Header("Colliders")]
		[SerializeField] Collider headCollider;
        [SerializeField] Collider torsoCollider;
        [SerializeField] Collider leftArmCollider;
        [SerializeField] Collider rightArmCollider;
        [SerializeField] Collider shieldCollider;   //This might have to have a separate script
        [SerializeField] Collider lanceCollider;


        #region Properties
        public PlayerData Data { get { return playerData; } }
        public LanceData LanceData { get { return lanceData; } }
        public ShieldData ShieldData { get { return shieldData; } }
        public HorseData HorseData { get { return horseData; } }

        #endregion

        void Awake()
        {
            SetPlayerData();
        }

        private void SetPlayerData()
        {
            ////These are some of the crucial first things in the game that must be set

            //Test - equipment switching - Set the current equipment to the first item in their arrays
            // currentLance = lances[0];
            // currentHorse = horses[0];
            // currentShield = shields[0];
            //Test

            playerData.Lance = this.lanceData;
            playerData.Shield = this.shieldData;
            playerData.Horse = this.horseData;
            
            playerData.Root = this.transform;
            playerData.Camera = this.camera;

            //Tricky bastard!
            playerMover = playerData.PlayerMover = this.GetComponent<PlayerMover>();
        }

        void Start()
        {
            // SetPlayerData();
            SetPlayerColliders();
            MountAllEquipment();
        }

        private void SetPlayerColliders()
        {
            //Retrieve these after all the other scripts have set their data in their Awake()
            playerData.HeadCollider = this.headCollider;
            playerData.TorsoCollider = this.torsoCollider;
            playerData.RightArmCollider = this.rightArmCollider;
            playerData.LeftArmCollider = this.leftArmCollider;
            playerData.ShieldCollider = this.shieldCollider;
            playerData.LanceCollider = this.lanceCollider;
        }

        public void SetPlayerPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            playerMover.SetPosition(position);
            playerMover.SetRotation(rotation);
        }

        public void MountAllEquipment()
        {

        }

        //Test - equipment switching
        // void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         SwitchLances();
        //     }
        // }
        // public void SwitchLances()
        // {
        //     lanceIndex++;
        //     if (lanceIndex >= lances.Count)
        //         lanceIndex = 0;

        //     if (currentLance != null)
        //         currentLance.Unequip();

        //     currentLance = lances[lanceIndex];
        //     currentLance.Equip();
        // }
        //Test - Equipment switching
    }
}