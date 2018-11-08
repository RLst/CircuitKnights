//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;
using XboxCtrlrInput;
using CircuitKnights.Variables;

namespace CircuitKnights.Objects
{

	[CreateAssetMenu(fileName = "New Player", menuName = "Player", order = 51)]
	public class Player : BaseObject
	{
		[TextArea][SerializeField] string description = "The player";
		// [SerializeField] GameObject mesh;
		// [SerializeField] public TransformVariable transform;
        // [SerializeField] GameObjectVariable gameObject;

    #region Cache
		//DONT KNOW ABOUT THESE... SEEM CLUNKY
        //[These could also be arrays ie. be able to change lances and shields]
		public Transform Root { get; set; }
        public Horse horse { get; set; }
        public Lance lance { get; set; }
        public Shield shield { get; set; }
		public Camera camera { get; set; }
        public PlayerMover playerMover { get; set; }
        	//WORK IN PROGRESS!!

		// public void SetHorse(Horse horse)
		// {
			
		// }
    #endregion

	#region Colliders
		public Collider LanceCollider { get; set; }
		public Collider HeadCollider { get; set; }
		public Collider TorsoCollider { get; set; }
		public Collider RightArmCollider { get; set; }
		public Collider LeftArmCollider { get; set; }
		public Collider ShieldCollider { get; set; }
			//WORK IN PROGRESS!!
	#endregion

	#region Points Of Interest
		Vector3Variable lookAtTarget;
	#endregion
		
	#region Player Numbers
		// [SerializeField] int playerNumber;
		// public int PlayerNumber { get { return playerNumber; }}
		public enum PlayerNumber {
			None, 	//0
			One,	//1
			Two		//2
		}
		[SerializeField] PlayerNumber playerNo;
		public PlayerNumber No { get { return playerNo; } } 	//(Number)
	#endregion

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
		//These are reset upon enable
		public float HeadHealth { get; set; }
		public float TorsoHealth { get; set; }
		public float LeftArmHealth { get; set; }
		public float RightArmHealth { get; set; }
		public float ShieldHealth { get; set; }
	#endregion

	#region Methods
		void Awake()
        {
			HeadCollider.GetComponent(typeof(Rigidbody));
            ResetStats();
        }

		void OnEnable()
		{
            // CachePlayerTools();
		}

        public void ResetStats()
		{
			//Use this say at the end of a match or round?
			HeadHealth = maxHeadHealth;
			TorsoHealth = maxTorsoHealth;
			LeftArmHealth = maxLeftArmHealth;
			RightArmHealth = maxRightArmHealth;
		}
        private void CachePlayerTools()
        {
            // lance = this.gameObject.GetComponent<Lance>();

            //Cache player's equipment (I hope this isn't too weird)
            // horse = ScriptableObject.FindObjectOfType<Horse>();

			// lance = ScriptableObject.FindObjectOfType<Lance>();
            // shield = ScriptableObject.FindObjectOfType<Shield>();

            // camera = this.gameObject.GetComponent<Camera>();

            // playerMover = this.gameObject.GetComponent<PlayerMover>();
			// if (!playerMover)
			// 	this.gameObject.GetComponentInParent<PlayerMover>();
			// if (!playerMover)
			// 	this.gameObject.GetComponentInChildren<PlayerMover>();
            	//(this.gameObject is from BaseObject)
        }

		public Player GetOpponent()
		{
			switch (playerNo)
			{
				case PlayerNumber.One:
					return GameSettings.Instance.PlayerTwo;
				case PlayerNumber.Two:
					return GameSettings.Instance.PlayerOne;
				default:
					return null;
			}
		}

		public void SetPosition(Vector3 position) {
			this.gameObject.transform.position = position;	//Is this OK? Could be hard to debug
		}
		public void EnableMovement() {
			playerMover.enabled = true;
		}
		public void DisableMovement() {
			playerMover.enabled = false;
		}
		public void EnableCamera() {
			camera.enabled = true;
		}
		public void DisableCamera() {
			camera.enabled = false;
		}
	#endregion
	}
}