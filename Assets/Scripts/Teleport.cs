using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
public GameObject YouGameObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == YouGameObject)
            {
                transform.position = new Vector3(0, 0, 0);//(where you want to teleport)
            }
    }
}
