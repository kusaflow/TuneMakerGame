using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakOnCollition : MonoBehaviour
{
    //2d collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<particleOnCollition>().PlayParticleEffect(collision);
        //destroy this gameobject
        if (AudioStackMngr.Instance.stack.Count <= 2)
            AudioStackMngr.Instance.stack.Enqueue(GetComponent<AudioSource>().clip);

        BlockManager.Instance.SaveBlock(this.gameObject);
        ScoreManager.Instance.AddScore(ScoreManager.Instance.scorePerBlock);

        Destroy(gameObject);
    }
}
