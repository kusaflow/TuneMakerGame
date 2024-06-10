using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalControl_solo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        BallManager.Instance.PreserveSpeed();
        globalStatic.DisablePopBtn = true;
        StartCoroutine(WaitForPlayerTap());
    }   


    IEnumerator WaitForPlayerTap()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        globalStatic.DisablePopBtn = false;

        Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tapPosition.z = 0; // Ensure the z-position is zero for 2D
        //Debug.Log("Tap Position: " + tapPosition);

        BallManager.Instance.SetBallsDirection(tapPosition);
        StartCoroutine(destroy_it());
    }

    IEnumerator destroy_it()
    {
        
        //wait for 4 seconds
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }


}
