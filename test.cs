using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

public struct sprawl1 : IJob
{
    public float headvalue;
    public float crVal;
    public float clVal;
    public NativeArray<bool> result;

    public void Execute()
    {
        //phase1
        result[0] = headvalue < 0.25f && crVal < 0.25f && clVal < 0.3f;
        //phase2
         result[1] = headvalue < 0.25f && crVal < 0.05f && clVal < 0.05f;
    }
}



public class test : MonoBehaviour
{
    public lambdaFuncs lams;
    public Animator animator; // reference to the Animator
    private bool prevsprwl1 = false;
    private bool prevsprwl2 = false;

     
    public void RunJobs(float yValue, float cr, float cl)
    {
        NativeArray<bool> sprawlresults = new NativeArray<bool>(2, Allocator.TempJob);
        //NativeArray<bool> result2 = new NativeArray<bool>(1, Allocator.TempJob);

        sprawl1 job1 = new sprawl1
        {
            headvalue = yValue,
            crVal = cr,
            clVal = cl,
            result = sprawlresults
        };

        

        // Schedule the jobs
        JobHandle job1Handle = job1.Schedule();
        

        // Wait for both jobs to complete
        //JobHandle.CombineDependencies(job1Handle, job2Handle).Complete();
        job1Handle.Complete();

        // After both jobs are complete, check if both conditions were met
        bool sprawl1 = sprawlresults[0] && sprawlresults[1];

        //sprawl->stand
        lams.animTrig(!prevsprwl1,!sprawlresults[0],() =>animator.SetTrigger("sprawltostand"));
        //stand->sprawl
        lams.animTrig(prevsprwl1,sprawlresults[0],() => animator.SetTrigger("standtosprawl"));
        //sprawl1->2
        lams.animTrig(prevsprwl2,sprawlresults[1],() =>animator.SetTrigger("sprawl1to2"));
        //sprawl2->1
        lams.animTrig(!prevsprwl2,!sprawlresults[1],() =>animator.SetTrigger("sprawl2to1"));


       

        
        prevsprwl1 = sprawlresults[0];
        prevsprwl2 = sprawlresults[1];
        // Don't forget to dispose of the NativeArrays when you're done
        sprawlresults.Dispose();
        
       
    }
}