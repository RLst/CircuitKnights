//DuckBike
//Tony Le
//9 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;
using System;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    [RequireComponent(typeof(Collider))]
    public class RightArmHealth : Damageable
    {
        //Right arm falls off upon death? Player loses lance?

        ////Events
        //Death event broadcast; Broadcast an event upon death of this limb to whomever wants to tune in
        public static event Action<PlayerData.PlayerNumber, float> OnRightArmHit = delegate { };
        public static event Action<PlayerData.PlayerNumber> OnRightArmDeath = delegate { };      //Subject or broadcaster; And observer needs to implement this

        [SerializeField] GameObject knockedOffPrefab;
        [SerializeField] GameObject meshToHide;
        Transform InstatiatePoint;




        void Awake()
        {
            //Register for the Iframe event
            Damageable.OnFirstHit += SetIFrames;
        }
        void Start()
        {
            playerData = GetComponentInParent<Player>().Data;
            opponentData = GetComponentInParent<Player>().Data.GetOpponent();
            Assert.IsNotNull(playerData, "Player data not found!");
            Assert.IsNotNull(opponentData, "Opponent data not found!");

            InstatiatePoint = transform;
        }


        void OnCollisionEnter(Collision other)
        {
            if (other.collider == opponentData.LanceCollider)
            {
                //If another limb or shield has already be hit
                if (!isInvincible)
                {
                    //Calculate impact; impact is the amount of damage based on the speed of the horse and lance attack rating
                    float attackMultiplier;
                    var attack = opponentData.LanceData.Attack;
                    var impact = CalculateImpact(attack, out attackMultiplier);

                    //This damageable is first hit; set the rest to temp invincibility
                    SetIFrames(playerData.No);

                    //Limb takes damage
                    TakeDamage(impact);

                    //Let ether know head was hit
                    OnRightArmHit(playerData.No, attackMultiplier);

                    //Knockback
                    // playerData.ImpactHandler.Execute(attackMultiplier);
                }
            }
        }


        public override void TakeDamage(float damage)
        {
            playerData.RightArmHP -= damage;

            if (playerData.RightArmHP <= 0)
                Death();
        }


        public override void Death()
        {
            ////Knock off left arm
            //Hide the mesh
            meshToHide.SetActive(false);

            //Spawn in new limb to simulate getting knocked off
            var newKnockedoff = Instantiate(knockedOffPrefab, InstatiatePoint.position, InstatiatePoint.rotation);

            //Let system know the Left Arm has been knocked off
            OnRightArmDeath(playerData.No);
            //TODO reduce lance accuracy?

            //Finally disable this object so no more commands will be received
            this.gameObject.SetActive(false);
        }

    }
}