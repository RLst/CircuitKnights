//Duckbike
//Tony Le
//1 Nov 2018

// using XboxCtrlrInput;
// using UnityEngine;
// using CircuitKnights.Objects;


// namespace CircuitKnights
// {
//     public class ControllerInput : IPlayerInput
//     {
//         [SerializeField] Knight player;

//         public float LeftAxisX { get; private set; }
//         public float LeftAxisY { get; private set; }

//         public float RightAxisX { get; private set; }

//         public float RightAxisY { get; private set; }

//         public float RightTrigger { get; private set; }

//         public float LeftTrigger { get; private set; }

//         public bool RightBumper { get; private set; }

//         public bool LeftBumper { get; private set; }

//         public bool A { get; private set; }

//         public bool B { get; private set; }

//         public bool X { get; private set; }

//         public bool Y { get; private set; }

//         public bool Up { get; private set; }

//         public bool Down { get; private set; }

//         public bool Left { get; private set; }

//         public bool Right { get; private set; }


//         public void Awake()
//         {
//             if (!player)
//                 Debug.LogAssertion("No player object set on this controller!");
//             else
//                 //Set it to use any controller input if no player object passed in
//                 player.controller = XboxController.All;
//         }

//         public void ReadInput()
//         {
//             LeftAxisX = XCI.GetAxis(XboxAxis.LeftStickX, player.Controller);
//             LeftAxisY = XCI.GetAxis(XboxAxis.LeftStickY, player.Controller);
            
//             RightAxisX = XCI.GetAxis(XboxAxis.RightStickX, player.Controller);
//             RightAxisY = XCI.GetAxis(XboxAxis.RightStickY, player.Controller);
            
//             LeftTrigger = XCI.GetAxis(XboxAxis.LeftTrigger, player.Controller);
//             RightTrigger = XCI.GetAxis(XboxAxis.RightTrigger, player.Controller);
            
//             RightBumper = XCI.GetButton(XboxButton.RightBumper, player.controller);
//             LeftBumper = XCI.GetButton(XboxButton.LeftBumper, player.controller);

//             A = XCI.GetButton(XboxButton.A, player.controller);
//             B = XCI.GetButton(XboxButton.B, player.controller);
//             X = XCI.GetButton(XboxButton.X, player.controller);
//             Y = XCI.GetButton(XboxButton.Y, player.controller);

//             Up = XCI.GetButton(XboxButton.DPadUp, player.controller);
//             Down = XCI.GetButton(XboxButton.DPadDown, player.controller);
//             Left = XCI.GetButton(XboxButton.DPadLeft, player.controller);
//             Right = XCI.GetButton(XboxButton.DPadRight, player.controller);

//         }

//     }
// }