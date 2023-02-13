using UnityEngine;

public class capFPS : MonoBehaviour
{
    void Start()
    {
         Application.targetFrameRate = 60;
        ///Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
