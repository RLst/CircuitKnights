//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;
using CircuitKnights;
using System.Collections.Generic;
using CircuitKnights.Cameras;
using CircuitKnights.Controllers;
using XboxCtrlrInput;
using CircuitKnights.Gear;
using System;

namespace CircuitKnights.Players
{
    public class Player : MonoBehaviour
    {
        // //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
        // [TextArea][Multiline] string description =
        //     "Sets all critical references inside the instance of Player.";
        [Header("Controls")]
        [Tooltip("Lerp")] public float LeanInertia = 0.8f;
        [SerializeField] XboxController controller;
        [SerializeField] XboxAxis lanceAxisX, lanceAxisY;
        [SerializeField] XboxAxis leanLeft, leanRight;
        [SerializeField] XboxAxis shieldAxisX, shieldAxisY;
        [SerializeField] XboxButton thrustLanceButton;

        public XboxController Controller { get { return controller; } }
        public XboxAxis LanceAxisX { get { return lanceAxisX; } }
        public XboxAxis LanceAxisY { get { return lanceAxisY; } }
        public XboxAxis LeanLeft { get { return leanLeft; } }
        public XboxAxis LeanRight { get { return leanRight; } }
        public XboxAxis ShieldAxisX { get { return shieldAxisX; } }
        public XboxAxis ShieldAxisY { get { return shieldAxisY; } }
        // public XboxButton ThrustLanceButton { get { return thrustLanceButton; } }

        [Header("Weapon Switching")]
        [SerializeField] Lance[] lances;
        [SerializeField] Shield[] shields;
        [SerializeField] Horse[] horses;
        int lanceIDX = 0, shieldIDX = 0, horseIDX = 0;
        Lance currentLance;
        Shield currentShield;
        Horse currentHorse;
        public Lance Lance { get { return currentLance; } }
        public Shield Shield { get { return currentShield; } }
        public Horse Horse { get { return currentHorse; } }


        [Header("Controllers")]
        [SerializeField] PlayerCamera playerCamera;
        public Animator Animator { get; private set; }      //Private set so that these can't be changed during runtime
        public ShieldController ShieldController { get; private set; }
        public PlayerIKHoldLance IKLanceHolder { get; private set; }
        public PlayerIKHoldShield IKShieldHolder { get; private set; }
        public PlayerIKLook IKLook { get; private set; }
        // ImpactHandler impactHandler;
        // public Animator Animator { get { return animator; } }

        [Header("Colliders")]
        [SerializeField] Collider headCollider;
        [SerializeField] Collider torsoCollider;
        [SerializeField] Collider leftArmCollider;
        [SerializeField] Collider rightArmCollider;
        [SerializeField] Collider shieldCollider;   //This might have to have a separate script
        [SerializeField] Collider lanceCollider;
   		public Collider HeadCollider { get { return headCollider; } }
		public Collider TorsoCollider { get { return torsoCollider; } }
		public Collider LeftArmCollider { get { return leftArmCollider; } }
		public Collider RightArmCollider { get { return rightArmCollider; } }
		public Collider ShieldCollider { get { return shieldCollider; } }
		public Collider LanceCollider { get { return lanceCollider; } }

        // #region Properties
        // public PlayerData Data { get { return playerData; } }
        // public LanceData LanceData { get { return lanceData; } }
        // public ShieldData ShieldData { get { return shieldData; } }
        // public HorseData HorseData { get { return horseData; } }
        // #endregion

        public enum Number { One = 0, Two }
        [Header("Player Number")]
        [SerializeField] Number number;
        public Number No { get { return number; } }     //(Number)


        [Header("Health")]
        [SerializeField] float maxHeadHP;
        [SerializeField] float maxTorsoHP;
        [SerializeField] float maxLeftArmHP;
        [SerializeField] float maxRightArmHP;

        //The stats that externals will actually reference from
        //These are reset upon enable
        public float HeadHP { get; set; }
        public float TorsoHP { get; set; }
        public float LeftArmHP { get; set; }
        public float RightArmHP { get; set; }
        public bool isHeadless { get { return HeadHP <= 0; } }
        public bool isDead { get { return TorsoHP <= 0; } }
        public bool isLeftArmDestroyed { get { return LeftArmHP <= 0; } }
        public bool isRightArmDestroyed { get { return RightArmHP <= 0; } }


        void OnEnable()
        {
            ResetStats();
        }

        void Start()
        {
            CacheControllers();
            InitEquipment();
            MountAllEquipment();
        }

        private void InitEquipment()
        {
            currentLance = lances[lanceIDX];
            currentShield = shields[shieldIDX];
            currentHorse = horses[horseIDX];
        }

        private void CacheControllers()
        {
            Animator = GetComponentInChildren<Animator>();
            ShieldController = GetComponentInChildren<ShieldController>();
            IKLanceHolder = GetComponentInChildren<PlayerIKHoldLance>();
            IKShieldHolder = GetComponentInChildren<PlayerIKHoldShield>();
            IKLook = GetComponentInChildren<PlayerIKLook>();
        }

        void Update()
        {
            TestSwitchLancesTick();
            // SwitchShields();
            // SwitchHorses();
        }

        private void TestSwitchLancesTick()
        {
            // Debug.Log("current index: " + lanceIDX);

            //BETA RUSH
            if (Input.GetKeyDown(KeyCode.I))
            {
                lanceIDX--;
                if (lanceIDX < 0) lanceIDX = 0;
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                lanceIDX++;
                if (lanceIDX > lances.Length - 1) lanceIDX = lances.Length - 1;
            }
            //Set the lances
            int i = 0;
            foreach (var lance in lances)
            {
                if (i == lanceIDX)
                {
                    currentLance = lance;
                    currentLance.Equip();
                }
                else
                    lance.Unequip();

                i++;
            }
        }
        // private void SwitchHorses()
        // {
        //     throw new NotImplementedException();
        // }

        // private void SwitchShields()
        // {
        //     throw new NotImplementedException();
        // }

        public void MountAllEquipment()
        {
            //Mount the lances
            foreach (var lance in lances)
            {
                lance.Equip();
            }
        }

        public void ResetStats()
        {
            //Use this say at the end of a match or round?
            HeadHP = maxHeadHP;
            TorsoHP = maxTorsoHP;
            LeftArmHP = maxLeftArmHP;
            RightArmHP = maxRightArmHP;
            //ShieldData.ResetHP();
        }

        internal Player GetOpponent()
		{
			switch (No)
			{
                case Number.One:
					return GameSettings.Instance.PlayerTwo;
				case Number.Two:
					return GameSettings.Instance.PlayerOne;
				default:
					Debug.LogError("Invalid player number");
					return null;
			}
		}
    }
}



// void Awake()
// {
//     // SetPlayerData();
// }

// void Start()
// {
//     // SetPlayerColliders();
// }

// private void SetPlayerData()
// {
//     ////[IS THIS ACTUALLY NECESSARY?]
//     ////These are some of the crucial first things in the game that must be set
//     playerData.LanceData = this.lanceData;
//     playerData.ShieldData = this.shieldData;
//     playerData.HorseData = this.horseData;

//     playerData.Root = this.transform;
//     playerData.Camera = this.playerCamera;
// 	playerData.Animator = this.playerAnimator;

//     ///Automatics
//     // playerData.ImpactHandler = this.impactHandler = this.GetComponent<ImpactHandler>();
//     playerData.Horse = horse = this.GetComponent<Horse>();
// 	playerData.ShieldController = this.shieldController = GetComponentInChildren<ShieldController>();
//     playerData.IKLanceHolder = this.IKLanceHolder = GetComponentInChildren<PlayerIKHoldLance>();
//     playerData.IKShieldHold = this.IKShieldHolder = GetComponentInChildren<PlayerIKHoldShield>();
//     playerData.IKLook = this.IKLook = GetComponentInChildren<PlayerIKLook>();
// }

// private void SetPlayerColliders()
// {
//     //Retrieve these after all the other scripts have set their data in their Awake()
//     playerData.HeadCollider = this.headCollider;
//     playerData.TorsoCollider = this.torsoCollider;
//     playerData.RightArmCollider = this.rightArmCollider;
//     playerData.LeftArmCollider = this.leftArmCollider;
//     playerData.ShieldCollider = this.shieldCollider;
//     playerData.LanceCollider = this.lanceCollider;
// }