using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour {

    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (GameControlller.gam)
        {
            if (GameControlller.gam.gameIsOver)
                return;
        }

        if(collision.gameObject.tag == "Projectile")
        {
            if (explosionPrefab)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (GameControlller.gam)
            {
                GameControlller.gam.TargetHit(scoreAmount, timeAmount);
            }

            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
   
}
