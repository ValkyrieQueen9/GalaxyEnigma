using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClicker : MonoBehaviour
{

    void Update()
    {
        /*
        RaycastHit hoverHit;
        Ray hoverRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(hoverRay, out hoverHit, 100.0f))
        {
            if (hoverHit.transform.gameObject.tag == "Cube")
            {
                //Play Highlight Animation???
            }
        }
        */

        //If mouse pressed and raycast hits gameobject with Cube tag:
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.tag == "Cube")
                {
                    //Trigger the rotate cube bool used by CubeInteract
                    hit.transform.gameObject.GetComponent<CubeInteract>().rotateCube = true;
                }
            }
        }
        



    }

}
