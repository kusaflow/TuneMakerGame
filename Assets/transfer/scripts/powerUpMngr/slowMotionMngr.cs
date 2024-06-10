using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotionMngr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
        StartCoroutine(destroy_it());
    }

    IEnumerator destroy_it()
    {
        //wait for 5 seconds
        yield return new WaitForSeconds(5.0f);
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}
