using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGameFrames : MonoBehaviour
{
    public int targetFrameRate = 60;

    public bool getFromGlobal = true;
    // Start is called before the first frame update
    void Start()
    {

        if (getFromGlobal)
        {
            targetFrameRate = globalStatic.targetFrameRate;
        }

        //set frame to max
        Application.targetFrameRate = targetFrameRate;
        
    }

}
