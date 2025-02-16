using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public float sensY; // y sensitvity
	public float sensX; // x sensitvity 

	public Transform orientation;

	float xRotation;
	float yRotation;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; // locks cursor
		Cursor.visible = false; // sets cursor invisible
	}

	private void Update()
	{
		// mouse input 
		float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
		float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

		yRotation += mouseX;
		xRotation -= mouseY;

		// prevents going past 90 degrees
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		// camera rotation and orientation
		transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation, 0);
	}
}
