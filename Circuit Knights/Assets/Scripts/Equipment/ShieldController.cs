using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights
{

    public class ShieldController : MonoBehaviour
    {
        ////Attach this to the shield

        //public enum InputType {
        //	LeftTrigger,
        //	XButton
        //}
        //public InputType inputType;

        public XboxController controller;

        //public XboxButton blockInput;
        public XboxAxis blockInput;

        public Vector3 maxBlockOffset;      //The max offset of where the shield will 


        // Update is called once per frame
        void Update()
        {
            Vector3 offset = Vector3.zero; 
            
            //offset = maxBlockOffset;
            offset = maxBlockOffset * XCI.GetAxis(blockInput, controller);
           
            transform.localPosition = offset;

        }
    }
}