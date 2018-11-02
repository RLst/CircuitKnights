//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;
using XboxCtrlrInput;
using CircuitKnights.Variables;

namespace CircuitKnights.Objects
{

	[CreateAssetMenu(fileName = "New Knight", menuName = "Knight", order = 51)]
	public class Knight : ScriptableObject
	{
		[TextArea][SerializeField] string description = "";
		[SerializeField] GameObject mesh;
		[SerializeField] public TransformVariable transform;
		// [SerializeField] GameObjectVariable gameObject;

#region Controls
		[Header("Controls")]
		[SerializeField] XboxController controller;
		[SerializeField] XboxAxis lanceAxisX, lanceAxisY;
		[SerializeField] XboxAxis leanAxisX, leanAxisY;
		[SerializeField] XboxAxis shieldAxisX, shieldAxisY;
		[SerializeField] XboxButton thrustLanceButton;

		public XboxController Controller { get { return controller; } }
		public XboxAxis LanceAxisX { get { return lanceAxisX; } }
		public XboxAxis LanceAxisY { get { return lanceAxisY; } }
		public XboxAxis LeanAxisX { get { return leanAxisX; } }
		public XboxAxis LeanAxisY { get { return leanAxisY; } }
		public XboxAxis ShieldAxisX { get { return shieldAxisX; } }
		public XboxAxis ShieldAxisY { get { return shieldAxisY; } }
		public XboxButton ThrustLanceButton { get { return thrustLanceButton; } }
#endregion
#region Stats
		[Header("Health")]
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

		// [Header("Lean & Dodge")]
		// [SerializeField]
#endregion

		void Awake()
		{
			ResetStats();
		}

		public void ResetStats()
		{
			//Use this say at the end of a match or round?
			HeadHealth = maxHeadHealth;
			TorsoHealth = maxTorsoHealth;
			LeftArmHealth = maxLeftArmHealth;
			RightArmHealth = maxRightArmHealth;
		}

		public void SetPosition(Vector3 position)
		{
			this.transform.Value.position = position;	//Is this OK? Could be hard to debug
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
