//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;
using CircuitKnights;
using System.Collections.Generic;
using CircuitKnights.Cameras;
using CircuitKnights.Controllers;

namespace CircuitKnights.Objects
{
    public class Player : MonoBehaviour
    {
        //// Sets references for player's lance, shield, horse so that the can be retrieved from the player's SO
        [TextArea][Multiline] string description =
            "Sets all critical references inside the instance of Player.";
		[SerializeField] PlayerData playerData;
		// [SerializeField] new Camera camera;
        [SerializeField] PlayerCamera playerCamera;


        [Header("Equipment")]

		[SerializeField] LanceData lanceData;
		[SerializeField] ShieldData shieldData;
        [SerializeField] HorseData horseData;

        [Header("Controllers")]
        [SerializeField] Animator playerAnimator;
        Horse horse;
        ShieldController shieldController;
        PlayerIKHoldLance IKLanceHolder;
        PlayerIKHoldShield IKShieldHolder;
        PlayerIKLook IKLook;
        ImpactHandler impactHandler;


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

        void Start()
        {
            SetPlayerColliders();
        }

        private void SetPlayerData()
        {
            ////[IS THIS ACTUALLY NECESSARY?]
            ////These are some of the crucial first things in the game that must be set
            playerData.LanceData = this.lanceData;
            playerData.ShieldData = this.shieldData;
            playerData.HorseData = this.horseData;

            playerData.Root = this.transform;
            playerData.Camera = this.playerCamera;
			playerData.Animator = this.playerAnimator;

            ///Automatics
            playerData.ImpactHandler = this.impactHandler = this.GetComponent<ImpactHandler>();
            playerData.Horse = horse = this.GetComponent<Horse>();
			playerData.ShieldController = this.shieldController = GetComponentInChildren<ShieldController>();
            playerData.IKLanceHolder = this.IKLanceHolder = GetComponentInChildren<PlayerIKHoldLance>();
            playerData.IKShieldHold = this.IKShieldHolder = GetComponentInChildren<PlayerIKHoldShield>();
            playerData.IKLook = this.IKLook = GetComponentInChildren<PlayerIKLook>();
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
    }
}