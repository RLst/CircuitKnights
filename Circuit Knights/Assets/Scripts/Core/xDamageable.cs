// using System;
// using UnityEngine;

// namespace CircuitKnights
// {
//     public abstract class Damageable : MonoBehaviour
//     {
//         ////Can be used not just on the player but inanimate objects too
//         float health;

//         public virtual void TakeDamage(float damageAmount)
//         {
//             health -= damageAmount;
//             if (health <= 0)
//                 Death();
//         }

//         public abstract void Death();
//         //Must be implemented by any object that derives from this class
//     }

// }