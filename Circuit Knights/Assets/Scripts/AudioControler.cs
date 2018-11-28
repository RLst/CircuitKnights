using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

    public AudioSource CheeringAS;
    public AudioClip CheeringAudioClip;

    public AudioSource RobotAS;
    public AudioClip RobotAudioClip;

    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            CheeringAS.clip = CheeringAudioClip;
            CheeringAS.PlayOneShot(CheeringAS.clip);

            // _asTwo.clip = audioClip;
            // _asTwo.PlayOneShot (_asTwo.clip);                  
        }
    }

}
