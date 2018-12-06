﻿//DuckBike
//Tony Le
//12 Nov 2018

using UnityEngine;

namespace CircuitKnights.Gear
{
    public abstract class Equipment : MonoBehaviour
    {
        //[TextArea][SerializeField]
        //string description =
        //    "Sets current object as a particular kind of equipment and mounting point.";
        //Temp
        // public ObjectData objectData;
        protected Transform mountPoint;	//Default mount point?

        internal void Equip()
        {
            transform.gameObject.SetActive(true);
            transform.SetParent(mountPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        internal void Equip(Transform customMountPoint)     //Temp - still figuring out how the mountpoint will be determined
        {
            transform.gameObject.SetActive(true);
            transform.SetParent(customMountPoint);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        internal void Unequip()
        {
            transform.SetParent(null);
            transform.gameObject.SetActive(false);
        }
    }
}

