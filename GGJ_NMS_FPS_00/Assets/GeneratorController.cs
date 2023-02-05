using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public bool enabled = false;

    public Material enabledMaterial;
    public Material disabledMaterial;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        changeMaterial();
    }

    private void OnValidate()
    {
        changeMaterial();
    }

    public void toggle()
    {
        enabled = !enabled;
        changeMaterial();
    }

    public void changeMaterial()
    {

        int numOfChildren = transform.childCount;
        Material toChange = enabled ? enabledMaterial : disabledMaterial;

        for (int i = 0; i < numOfChildren; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<MeshRenderer>().material = toChange;

        }

    }
}
