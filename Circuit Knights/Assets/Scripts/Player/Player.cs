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

        // //Test - Weapon switching
        // [SerializeField] Equipment[] lances;
        // [SerializeField] Equipment[] shields;
        // [SerializeField] Equipment[] horses;
        // int lanceIndex = 0;
        // int shieldIndex = 0;
        // int horseIndex = 0;
        // Equipment currentLance;
        // Equipment currentShield;
        // Equipment currentHorse;


        [Header("Controllers")]
        [SerializeField] PlayerMover playerMover;
        [SerializeField] Animator playerAnimator;
        [SerializeField] ShieldController shieldController;
        [SerializeField] PlayerIKHoldLance IKLanceHolder;
        [SerializeField] PlayerIKHoldShield IKShieldHolder;
        [SerializeField] PlayerIKLook IKLook;


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
            ////[IS THIS ACTUALLY NECESSARY?]
            ////These are some of the crucial first things in the game that must be set

            //Test - equipment switching - Set the current equipment to the first item in their arrays
            // currentLance = lances[0];
            // currentHorse = horses[0];
            // currentShield = shields[0];
            //Test

            playerData.LanceData = this.lanceData;
            playerData.ShieldData = this.shieldData;
            playerData.HorseData = this.horseData;

            playerData.Root = this.transform;
            playerData.Camera = this.camera;

            //Tricky bastard! Set both this and playerData
            playerData.PlayerMover = playerMover = this.GetComponent<PlayerMover>();
			playerData.Animator = playerAnimator;
			// playerData.Animator = playerAnimator = this.GetComponentInChildren<Animator>();
			playerData.ShieldController = this.shieldController = GetComponentInChildren<ShieldController>();
            playerData.IKLanceHolder = this.IKLanceHolder = GetComponentInChildren<PlayerIKHoldLance>();
            playerData.IKShieldHold = this.IKShieldHolder = GetComponentInChildren<PlayerIKHoldShield>();
            playerData.IKLook = this.IKLook = GetComponentInChildren<PlayerIKLook>();
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