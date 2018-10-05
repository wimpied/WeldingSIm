using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadsInCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bead"))
        {
            BeadsOutOfLine.Add(other.gameObject);
        }
    }

    public List<GameObject> BeadsOutOfLine;

    void Start()
    {
        BeadsOutOfLine = new List<GameObject>();
    }
 
}
