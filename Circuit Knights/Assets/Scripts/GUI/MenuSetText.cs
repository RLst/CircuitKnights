//DuckBike
//Tony Le
//6 Nov 2018

using UnityEngine;
using UnityEngine.UI;
using CircuitKnights.Variables;

namespace CircuitKnights
{
    public class MenuSetText : MonoBehaviour
    {
		[SerializeField] StringVariable menuText;
		Text text;

		void Start(){
			text = this.GetComponent<Text>();
		}
		void Update(){
			text.text = menuText.Value;
		}
    }
}