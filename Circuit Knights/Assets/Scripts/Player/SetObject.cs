//Duckbike
//Tony Le
//3 Nov 2018

using UnityEngine;

namespace CircuitKnights.Objects
{
    [DisallowMultipleComponent] //because a lance cannot be a shield or vice versa
    public class SetObject : MonoBehaviour
    {
        [TextArea][SerializeField] string description = 
            "Sets actual custom Circuit Knights object data to this object and handles mounting.";
        [SerializeField] BaseObject CKObject;      //Each object can only have one obj data associated with it
        [SerializeField] Transform mountPoint;

        // public BaseObject Data { get { return data; } }  
            //Nope! Otherwise reference this would look like this: 
            //...SetObject.Data.gameObject.GetComponent()
            //Instead reference object through the player ie:
            //GameSettings.Players[1].

        void Awake()
        {
            //Set object references
            CKObject.gameObject = this.gameObject;
        }

        void Start()
        {
            //Mount the object
            if (mountPoint)
            {
                Mount();
            }
        }
        public void Mount()
        {
            transform.SetParent(mountPoint);
            transform.gameObject.SetActive(true);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        public void UnMount()
        {
            transform.SetParent(null);
            transform.gameObject.SetActive(false);
        }

        // bool toggle = true;
        // void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.M))
        //     {
        //         toggle = !toggle;
        //         Debug.Log(toggle);
        //         if (toggle)
        //         {
        //             Mount(); Debug.Log("mount");
        //         }
        //         else
        //         {
        //             UnMount(); Debug.Log("unmount");
        //         }
        //     }
        // }
    }

}