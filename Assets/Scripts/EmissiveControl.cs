using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveControl : MonoBehaviour
{

    public float CoolDownTime;
    public Color EmissionColor;
    bool emissive = true;
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", EmissionColor * Mathf.LinearToGammaSpace(1));
    }
    bool fadeTest;
    void Update()
    {

    
        CoolDownFade();

        if (emission <= 0)
            Destroy(gameObject);
    }

    bool changeEmission = false;
    float emission = 1;
    float alpha = 1;
    void CoolDownFade()
    {
        emission = Mathf.Clamp01(emission - (Time.deltaTime / CoolDownTime));

        Color finalColor = EmissionColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
        //Debug.Log(emission);

    }



}

