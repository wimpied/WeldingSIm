using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HelmetBehaviour : MonoBehaviour {

    public Animator HelmetAnimator;
    public Light WeldPointLight;
    public LensFlare WeldPointFlare;
    public SteamVR_TrackedController Controller;

	void Start () {

        Controller.TriggerClicked += Controller_TriggerClicked;
        
        HandHeldHelmetObject.SetActive(false);
    }

    private void Controller_TriggerClicked(object sender, ClickedEventArgs e)
    {

        if (helmetIsOpen) FlipHelmetClosed();
        else FlipHelmetOpen();
    }


    public GameObject HandHeldHelmetObject;
    public GameObject HeadHelmetObject;
    public Transform eyeObject;
    public float CriticalHandHeldScreenToEyeDistance;
    bool handHeldHelmetActive = false;
    public bool helmetIsOpen;
	void Update () {

       
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!handHeldHelmetActive)
            {
                HandHeldHelmetObject.SetActive(true);
                HeadHelmetObject.SetActive(false);
                handHeldHelmetActive = true;
            }
            else
            {
                HandHeldHelmetObject.SetActive(false);
                HeadHelmetObject.SetActive(true);
                handHeldHelmetActive = false;
            }

        }

	}

    void FlipHelmetOpen()
    {
        HelmetAnimator.Play("Open");
        helmetIsOpen = true;
    }

    void FlipHelmetClosed()
    {
        HelmetAnimator.Play("Close");
        helmetIsOpen = false;
    }
}
