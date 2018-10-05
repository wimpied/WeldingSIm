using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WeldingBehaviour : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public float ArcDistance;
    public GameObject ArcObject;
    public GameObject ParticleSystems;
    public float DistanceFromTipToObject;
    public float ScaleIncreaseFactor;
    public float maxScale;
    GameObject currentRod;
    public float TotalWeldingTimePerRod;
    bool shortening;
    public SteamVR_TrackedController Controller;
    public GameObject HapticWarningDebug;
	public GameObject BadWeldSoundObject;
	public GameObject GoodWeldSoundObject;
	
	
    bool hitWeldableArea = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WeldableArea")
        {
	        hitWeldableArea = true;
	        BadWeldSoundObject.SetActive(true);
	        HapticWarningDebug.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "WeldableArea")
        {
	        hitWeldableArea = false;
	        BadWeldSoundObject.SetActive(false);
	        HapticWarningDebug.SetActive(false);
	       
        }
    }

    private void OnEnable()
    {
        currentRod = GameObject.FindGameObjectWithTag("ActiveRod").transform.parent.gameObject;

    }

    public bool StartArc;
    bool lensFlareActive = true;
    public float newBeadDistance;

    private void Update()
	{

        #region debug stuff and helpers
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (lensFlareActive)
            {
                ArcObject.GetComponentInChildren<LensFlare>().enabled = false;
                lensFlareActive = false;
            } 
            else
            {
                ArcObject.GetComponentInChildren<LensFlare>().enabled = true;
                lensFlareActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                debugMode = true;
            }

        }
#endregion

        ray.origin = transform.position;
        ray.direction = transform.up * ArcDistance;

        if (debugMode) Debug.DrawRay(transform.position, transform.up * ArcDistance, Color.green);

        if (Physics.Raycast(ray, out hit, ArcDistance))
        {

            if (hit.collider.tag == "WeldableArea")
            {
                SteamVR_Controller.Input((int)Controller.controllerIndex).TriggerHapticPulse(1000);



                ArcObject.SetActive(true);
                ArcObject.transform.position = hit.point;

                //check whether to place new bead or scale old one
                if (beadObject != null && Vector3.Distance(beadObject.transform.position, hit.point) <= newBeadDistance)
                {
                    ScaleBead();
                }
                else
                {
                    MakeNewBead(hit.point);
                }
                ShortenRod();
                DistanceFromTipToObject = Vector3.Distance(transform.position, hit.point);
            }
            
        }
        else ArcObject.SetActive(false);

    }

    void ScaleBead()
    {
        Vector3 beadScale = beadObject.transform.localScale;
        if(beadScale.x <= maxScale)
        {
            beadScale *= ScaleIncreaseFactor;
        }
        beadObject.transform.localScale = beadScale;
    }

    public GameObject beadObjectPrefab;
    public bool debugMode = true;
   
    public Transform BeadParent;
    GameObject beadObject;
    void MakeNewBead(Vector3 hitLocation)
    {
        beadObject = Instantiate(beadObjectPrefab, ArcObject.transform.position, Quaternion.identity);
        beadObject.transform.SetParent(BeadParent);

    }

    void ShortenRod()
    {
        currentRod.transform.localScale -= Vector3.up * Time.deltaTime / TotalWeldingTimePerRod;
    }


}
