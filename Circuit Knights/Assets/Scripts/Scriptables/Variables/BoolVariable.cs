//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;

namespace CircuitKnights.Variables
{

	[CreateAssetMenu(fileName = "New Bool", menuName = "Variables/Bool", order = 33)]
	public class BoolVariable : ScriptableObject
	{
		[Multiline]
		public string description = "";
		public bool Value;
	}

}