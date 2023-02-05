using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorManager : MonoBehaviour
{
    public Material Error;
    public Material Working;

    private int state = 0;

    public void changeMaterial()
    {
        if (state == 0)
        {
            state = 1;
            GetComponent<MeshRenderer>().material = Error;
        }
        else
        {
            state = 0;
            GetComponent<MeshRenderer>().material = Working;
        }
    }
}
