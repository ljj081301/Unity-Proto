using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    ParticleSystem particle = null;
    SphereMover sphere = GameObject.Find("sphere").GetComponent<SphereMover>();
 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (sphere.chara_stat == "die")
        {
            if (particle)
            {
                if (particle.isPlaying == true)
                {
                    particle.Stop();
                }
                else
                {
                    particle.Play();
                }
            }
        }

    }
}
