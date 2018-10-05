using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StraightLineAssessment : MonoBehaviour {

    public GameObject[] StraightLineAssessmentObjects;
    public TextMeshProUGUI StraightLineAssessmentText;

    public float TotalBeadsOutOfAlignment;
    public float TotalBeadsPlaced;

    public void AssessAlignment()
    {
        //get all beads out of alignment (touching colliders)
        foreach (GameObject item in StraightLineAssessmentObjects)
        {
            TotalBeadsOutOfAlignment += item.GetComponent<BeadsInCollider>().BeadsOutOfLine.Count;
        }

        //get all beads placed
        TotalBeadsPlaced = GameObject.FindGameObjectsWithTag("Bead").Length;

        //assign to text
        StraightLineAssessmentText.text = string.Format("Beads in line: {0:##.#}%", 100 * (1 - (TotalBeadsOutOfAlignment / TotalBeadsPlaced)));
       

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AssessAlignment();
        }
    }

}
