using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (GameControlller.gam)
        {
            GameControlller.gam.Restart();
        }
    }
}
