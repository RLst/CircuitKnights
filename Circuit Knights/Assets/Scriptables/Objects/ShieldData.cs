﻿//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Objects
{

    [CreateAssetMenu(fileName = "New Shield Data", menuName = "Shield", order = 54)]
    public class ShieldData : ObjectData
    {
        [TextArea][SerializeField] string description = 
            "Blocks the lance attacks. Has hit points. Will destroy after losing all of its ";
        [Tooltip("Lower is smoother")][Range(0f, 1f)][SerializeField] float smoothness = 0.25f;
        [SerializeField] float mass = 10f;

        [Header("Stats")]
        [SerializeField] float maxHP = 100;
        [SerializeField] float defense = 10f;
        public float Defense { get { return defense; } }

        [Header("Offsets")]
        [SerializeField] Vector3 restingOffset;
        [SerializeField] Vector3 restingAngOffset;
        [SerializeField] Vector3 blockingOffset;
        [SerializeField] Vector3 blockingAngOffset;


		public float HP { get; set; }
        public bool IsDead { get; private set; }
        public float tValue { get { return smoothness; } }
        public Vector3 RestingOffset { get; private set; }
        public Vector3 RestingAngOffset { get; private set; }
        public Vector3 BlockingOffset { get { return blockingOffset; } }
        public Vector3 BlockingAngOffset { get { return blockingAngOffset; } }


        void OnEnable()
        {
            ResetHP();
        }

        public void ResetHP()
        {
            HP = maxHP;
            IsDead = false;
        }

        public void TakeDamage(float damage)
        {
            HP -= damage;
            if (HP <= 0)
                Kill();
        }

        public void Kill()
        {
            IsDead = true;
        }
    }
}