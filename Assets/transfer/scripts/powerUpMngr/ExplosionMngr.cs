using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMngr : MonoBehaviour
{
    public float explosionRadius = 2.0f;
    public GameObject Explostion;


    // Start is called before the first frame update
    void Start()
    {
        globalStatic.DisablePopBtn = true;
        StartCoroutine(WaitForExplosiveTap());
    }

    private IEnumerator WaitForExplosiveTap()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        globalStatic.DisablePopBtn = false;

        Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tapPosition.z = 0; // Ensure the z-position is zero for 2D
        Debug.Log("Tap Position: " + tapPosition);

        Explostion = Instantiate(Explostion, tapPosition, Quaternion.identity);


        ExplodeAtPosition(tapPosition);
        StartCoroutine(destroy_it());
    }

    private void ExplodeAtPosition(Vector3 position)
    {
        Collider2D[] objectsToDestroy = Physics2D.OverlapCircleAll(position, explosionRadius);

        foreach (Collider2D obj in objectsToDestroy)
        {
            // Check if the object is a block or a ball
            if (obj.CompareTag("Block") || obj.CompareTag("Ball") || obj.CompareTag("Brick"))
            {
                ScoreManager.Instance.AddScore(ScoreManager.Instance.scorePerBlock);
                Destroy(obj.gameObject);
            }
        }
    }

    IEnumerator destroy_it()
    {

        //wait for 4 seconds
        yield return new WaitForSeconds(3.0f);
        Destroy(Explostion);
        Destroy(gameObject);
    }
}
