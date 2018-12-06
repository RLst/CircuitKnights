// //Duckbike
// //Tony Le
// //3 Nov 2018

// using UnityEngine;

// namespace CircuitKnights.Objects
// {
//     [DisallowMultipleComponent] //because a lance cannot be a shield or vice versa
//     public class SetObject : MonoBehaviour
//     {
//         ////NOTE: Maybe this doesn't need to be set on the character object
//         //[TextArea][SerializeField] string description = 
//         //    "Sets actual custom Circuit Knights object data to this object and handles mounting.";
//         [SerializeField] ObjectData objectData;      //Each object can only have one obj data associated with it
//         [SerializeField] Transform mountPoint;

//         // public BaseObject Data { get { return data; } }  
//             //Nope! Otherwise reference this would look like this: 
//             //...SetObject.Data.gameObject.GetComponent()
//             //Instead reference object through the player ie:
//             //GameSettings.Players[1].

//         void Awake()
//         {
//             //Set object references
//             ////WHY DO I NEED TO DO THIS?
//             objectData.gameObject = this.gameObject;      ////THIS MIGHT NEED TO CHANGE!!!
//         }

//         void Start()
//         {
//             //Mount the object
//             if (mountPoint)
//             {
//                 Mount();
//             }
//         }
//         public void Mount() 
//         ////NOTE! This cannot remount after deactivating itself. Must be controlled by a manager outside?
//         {
//             objectData.gameObject.SetActive(true);
//             objectData.gameObject.transform.SetParent(mountPoint);
//             objectData.gameObject.transform.localPosition = Vector3.zero;
//             objectData.gameObject.transform.localRotation = Quaternion.identity;
//             objectData.gameObject.transform.localScale = Vector3.one;
//         }
//         public void UnMount()
//         {
//             objectData.gameObject.SetActive(false);
//             objectData.gameObject.transform.SetParent(null);
//         }

//         // bool toggle = true;
//         // void Update()
//         // {
//         //     if (Input.GetKeyDown(KeyCode.M))
//         //     {
//         //         toggle = !toggle;
//         //         Debug.Log(toggle);
//         //         if (toggle)
//         //         {
//         //             Mount(); Debug.Log("mount");
//         //         }
//         //         else
//         //         {
//         //             UnMount(); Debug.Log("unmount");
//         //         }
//         //     }
//         // }
//     }

// }