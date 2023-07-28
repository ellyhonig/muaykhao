using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrestler : MonoBehaviour
{
    public test jobster;
    public lambdaFuncs lams;
    float height;
    public GameObject Cr;
    public GameObject Cl;
    public GameObject hmd;
    // Start is called before the first frame update
    void Start()
    {
        height = hmd.transform.position.y;
        //jobster = new test();
    }

    // Update is called once per frame
    void Update()
    {
        jobster.RunJobs(lams.getNormalHeight(hmd.transform.position,height),lams.getNormalHeight(Cr.transform.position,height),lams.getNormalHeight(Cl.transform.position,height));
         
    }
}
