using UnityEngine;

public class capFPS : MonoBehaviour
{
    void Start()
    {
         Application.targetFrameRate = 30;
        ///Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
