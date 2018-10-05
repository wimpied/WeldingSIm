using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour {

    Light light;
    LensFlare lensFlare;
    HelmetBehaviour helmetBehaviour;
    public GameObject HandHeldScreen;
    public float MinLight = 5;
    public float MaxLight = 10;

    private void Start()
    {
        lensFlare = GetComponent<LensFlare>();
        helmetBehaviour = FindObjectOfType<HelmetBehaviour>();
    }

	void Update () {
       
        lensFlare.brightness = Random.Range(MinLight, MaxLight);

        if(!helmetBehaviour.helmetIsOpen)
        {
            lensFlare.brightness = Random.Range( 0.01f * MinLight, 0.02f * MaxLight);
        }

	}

   
}
