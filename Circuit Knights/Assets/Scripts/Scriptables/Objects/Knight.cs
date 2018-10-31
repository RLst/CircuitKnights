//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights.Objects
{

	[CreateAssetMenu(fileName = "New Knight", menuName = "Knight", order = 51)]
	public class Knight : ScriptableObject
	{
		[Multiline] [SerializeField] string description = "";

		[SerializeField] GameObject mesh;

		[Header("Controls")]
		public XboxController controller;
		public XboxAxis lanceAxisX, lanceAxisY;
		public XboxAxis leanAxisX, leanAxisY;
		public XboxAxis shieldAxis;


		[Header("Starting Stats")]
		//These WILL NOT GET MODIFIED DURING RUNTIME
		[SerializeField] float maxHeadHealth;
		[SerializeField] float maxTorsoHealth;
		[SerializeField] float maxLeftArmHealth;
		[SerializeField] float maxRightArmHealth;

		//The stats that externals will actually reference from
		//These are reset at the start of 
		public float HeadHealth { get; set; }
		public float TorsoHealth { get; set; }
		public float LeftArmHealth { get; set; }
		public float RightArmHealth { get; set; }
		float TotalHealth		//Don't know about this ie. If Torse loses all health then it should kill the player
		{
			get
			{
				return HeadHealth + TorsoHealth + LeftArmHealth + RightArmHealth;
			}
		}


		void Awake()
		{
			ResetStats();
		}

		public void ResetStats()
		{
			HeadHealth = maxHeadHealth;
			TorsoHealth = maxTorsoHealth;
			LeftArmHealth = maxLeftArmHealth;
			RightArmHealth = maxRightArmHealth;
		}

	}
}


/*
//bunch of example player stats
[SerializeField] float strength;
[SerializeField] float defence;
[SerializeField] float power;
[SerializeField] float speed;
[SerializeField] float electricalResistance;
[SerializeField] float electricalPower;
*/
