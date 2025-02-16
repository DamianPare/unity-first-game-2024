using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{

   public GameObject player;
   public Vector3 target;
   public AudioSource audioSource;
   public AudioClip killClip;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(killClip);
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject == player)
        {
            Debug.Log("Check");
            player.transform.position = target;
        }
    }
}
