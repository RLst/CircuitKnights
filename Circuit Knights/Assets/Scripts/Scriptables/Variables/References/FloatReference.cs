//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using System;

namespace CircuitKnights.Variables
{

[Serializable]
public class FloatReference {
	public bool UseConstant = true;
	public float ConstantValue;
	public FloatVariable Variable;

	public FloatReference() {}	//Default constructor

	public FloatReference(float value)
	{
		UseConstant = true;
		ConstantValue = value;
	}

	public float Value
	{
		get {
			return UseConstant ? ConstantValue : Variable.Value;
		}
		// set {
		// 	if (UseConstant)
		// 		ConstantValue = value;
		// 	else
		// 		Variable.Value = value;
		// }
	}

	public static implicit operator float(FloatReference reference)
	{
		return reference.Value;
	}
}

}