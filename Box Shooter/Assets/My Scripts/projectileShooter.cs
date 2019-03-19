using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour {

    public GameObject projectile;
    public float power = 10.0f;
   

    public AudioClip sfxClip;
    public float volumeScale = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") || Input.GetButton("Jump"))
        {
            if(projectile)
            {
                GameObject newProjectiles = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

                if(!newProjectiles.GetComponent<Rigidbody>())
                {
                    newProjectiles.AddComponent<Rigidbody>();
                }
                newProjectiles.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                if (sfxClip)
                {
                    if(newProjectiles.GetComponent<AudioSource>())
                    {
                        newProjectiles.GetComponent<AudioSource>().PlayOneShot(sfxClip, volumeScale);
                    }
                    else
                    {
                        AudioSource.PlayClipAtPoint(sfxClip, newProjectiles.transform.position);
                    }
                }
            }

        }
	}
}
