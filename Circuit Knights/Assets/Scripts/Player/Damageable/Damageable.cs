//DuckBike
//Tony Le
//9 Nov 2018

using System;
using System.Collections;
using CircuitKnights.Objects;
using UnityEngine;
using UnityEngine.Assertions;

namespace CircuitKnights
{
    public abstract class Damageable : MonoBehaviour
	{
        protected bool isInvincible = false;
        protected PlayerData playerData;
        protected PlayerData opponentData;

        public static event Action<PlayerData.PlayerNumber, float> OnFirstHit = delegate {};    //Params(playerNo, impact)
        public abstract void TakeDamage(float damage);
        public abstract void Death();

        void Awake()
        {
            OnFirstHit += SetIFrames;
        }

        protected void SetIFrames(PlayerData.PlayerNumber playerHit, float impact)
        {
            StartCoroutine(IFrames(playerHit, impact));
        }
		protected IEnumerator IFrames(PlayerData.PlayerNumber playerHit, float impact)
		{
            if (playerHit == playerData.No)
            {
                const float timeFactorTweak = 1f;
                //Make this invicible for a period of time
                isInvincible = true;
                yield return new WaitForSeconds(impact * timeFactorTweak);
                isInvincible = false;
            }
		}
    }
}




        // public abstract void AutoRetrieveReferences();
        // public abstract void AssertReferences();
        // public abstract void OnFirstHit(PlayerData.PlayerNumber);

        // void Start()
        // {
        //     Auto retrieve references based on what it's attached to
        //     AutoRetrieveReferences();
        //     Assertions();
        // }

        // private void AutoRetrieveReferences()
        // {
        //     //This cannot work because this is an abstract class than can't be placed on an object right?
        //     playerData = GetComponentInChildren<Player>().Data;
        //     opponentsLanceCollider = playerData.GetOpponent().LanceCollider;
        // }

        // private void Assertions()
        // {
        //     Assert.IsNotNull(playerData, "Player data not found!");
        //     Assert.IsNotNull(opponentsLanceCollider, "Opponent's lance not found");
        // }



        // public virtual void TakeDamage(float damage)
        // {
        //     Debug.Log("Damage taken!");
        //     // health -= damage;
        //     // if (health <= 0)
        //     // 	Death();
        // }
        // public virtual void Death()
        // {
        // 	Debug.Log("Dead");
        // }


// public abstract class Damageable
// {
//     public int HP;
//     public Animator Anim;
//     AudioSource audio;
//     public AudioClip LameHitSound;
//     public AudioClip HealSound;
//     public AudioClip DamageSound;

//     //maybe some cooldown timer logic, particle effects, damage sprites etc.. 

//     public virtual void TakeDamage(int amt)
//     {
//         HP -= amt;
//         if (HP <= 0)
//         {
//             Death();
//         }
//     }

//     public virtual void Hit(int amt)
//     {
//         if (amt == 0)
//         {
//             //play sound effect for lame damage
//             audio.PlayOneShot(LameHitSound, 0.7F);
//             Anim.SetTrigger("TakeLittleDamage");
//         }
//         else if (amt < 0)
//         {
//             //play effects and such for healing
//             audio.PlayOneShot(HealSound, 0.7F);
//             Anim.SetTrigger("Heal");
//         }
//         else
//         {
//             //shake screen, preform screen shake and other effects for damage
//             audio.PlayOneShot(DamageSound, 0.7F);
//             Anim.SetTrigger("TakeSolidDamage");
//         }
//     }

//     public abstract void Death();
// }

// //and Inherit from it 
// public class PlayerHealth : Damageable
// {
//     public override void Death()
//     {
//         //Call Game Over logic
//     }

// }
// //and override as you need
// public class EnemyHealth : Damageable
// {
//     public override void Death()
//     {
//         //play death anim, set death variables
//     }
// }

// public class BoxHealth : Damageable
// {
//     void Start()
//     {
//         HP = 1;
//     }
//     public override void Death()
//     {
//         //Provide player with Item;
//     }
//     public override void Hit(int amt)
//     {
//         if (amt > 0)
//         {
//             audio.PlayOneShot(DamageSound, 0.7F);
//             Anim.SetTrigger("TakeSolidDamage");
//         }
//     }
// }
