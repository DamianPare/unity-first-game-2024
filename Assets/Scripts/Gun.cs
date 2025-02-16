using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	// variables
	public Transform bulletSpawnPoint;
	public GameObject bulletPrefab;
	public float bulletSpeed; 
	public float lastClickTime;
	public float shootingDelay;
	public AudioSource audioSource;
	public AudioClip gunShotclip;

    private void Update()
    {
        // check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // check if one second has passed
            if (Time.time - lastClickTime >= shootingDelay)
            {
				Shoot(); //shoot fuction
				lastClickTime = Time.time; // "reset" delay, more like a timestamp
            }
        }
	}

	void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			audioSource.PlayOneShot(gunShotclip);
			var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // creates bullet
			bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed; // gives velocity
		}		
	}
}
