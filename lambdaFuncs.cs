using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.Collections;
public class lambdaFuncs : MonoBehaviour
{

    public System.Func<Vector3,float,float> getNormalHeight;
    public System.Action<NativeArray<bool>, NativeArray<bool>, Action> sprawl1Trig;
    public System.Action<bool,bool, Action> animTrig;

    public void setUpFuncs()
    {
        getNormalHeight = (pos, height) => pos.y / height;

        animTrig = (prev,result, trigger) =>{ if(prev != result && result) trigger(); };

        //sprawl1Trig = (sprawlprev, sprawlresults, tosprawl1) => if (sprawlprev[0] != sprawlresults[0] && sprawlresults[0]) tosprawl1();
            
    }

  
  
    void Awake()
    {
        setUpFuncs();
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
