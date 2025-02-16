using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    public int pointValue = 1;
	public Orb Orbs;
    public Material[] materials;
    [SerializeField] int OccludedLayer;
    public AudioSource audioSource;
	public AudioClip killClip;


		void OnCollisionEnter(Collision collision)
		{
            audioSource.PlayOneShot(killClip);
            OrbManager orbManager = FindObjectOfType<OrbManager>();
            orbManager.MoveOrbsToNewPositions();
			ScoreManager.instance.AddPoint(pointValue);
		}

		void Start()
        {
            gameObject.layer = 0;
        }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.layer = OccludedLayer;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            gameObject.layer = 0;
        }
    }
}