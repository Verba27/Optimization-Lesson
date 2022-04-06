using System;
using UnityEngine;

public class UpdateChanger : MonoBehaviour
{
    private IUpdate[] updatables;
    private int cur;

    private void Start()
    {
        cur = 0;
    }

    private void Update()
    {
        if (updatables == null)
        {
            return;
        }

        foreach (var u in updatables)
        {
            if (updatables != null)
            {
                u.Tick();
            }
            
        }
        
    }

    public void Instance(int count)
    {
        updatables = new IUpdate[count];
    }

    public void Add(IUpdate obj)
    {
        updatables[cur++] = obj;
    }
}