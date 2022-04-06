using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    const int numberOfTests = 5000;
    Transform test;

    void PerformGetComponentString()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = (Transform) GetComponent("Transform");
        }
    }
    void PerformGetComponentGeneric()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = GetComponent<Transform>();
        }
    }

    

    void PerformGetComponentType()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = (Transform) GetComponent(typeof(Transform));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformGetComponentString();
            PerformGetComponentGeneric();
            
            PerformGetComponentType();
        }
    }
}
