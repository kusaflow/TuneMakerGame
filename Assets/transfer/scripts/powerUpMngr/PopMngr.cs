using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopMngr : MonoBehaviour
{
    public int popCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        //pop out 2 powers and destroy the object
        for (int i = 0; i < popCount; i++)
        {
            PowerUpManager.Instance.PopPowerUp();
        }
        StartCoroutine(destroy_it());
    }

    IEnumerator destroy_it()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

}
