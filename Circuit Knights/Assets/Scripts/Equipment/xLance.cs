//DuckBike
//Tony Le
//12 Nov 2018

using UnityEngine;

namespace CircuitKnights
{
    public class xLance : MonoBehaviour
    {
        private Transform mountPoint;

		internal void Equip(Transform mountPoint)
		{
            transform.gameObject.SetActive(true);
            transform.SetParent(mountPoint);
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

