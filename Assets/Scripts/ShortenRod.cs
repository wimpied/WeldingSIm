using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortenRod : MonoBehaviour {

    public GameObject currentRod;
    public float shorteningRatePerSecond;
    bool shortening;
    private void OnEnable()
    {
        currentRod = GameObject.FindGameObjectWithTag("ActiveRod");
    }



    void Shorten()
    {
        currentRod.transform.localScale -= transform.up * Time.deltaTime / shorteningRatePerSecond;
    }
}
