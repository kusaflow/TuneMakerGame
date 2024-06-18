using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickProvider : MonoBehaviour
{

    //int IdxChoosenForBrick = 0;


    public GameObject provideBlockToDraw ()
    {

        float rand = Random.Range(0, 100);

        if (rand < ManageLevelBehaviour.Instance.SpikeRateOutOf100)
        {
            GameObject retGame_spike = ManageLevelBehaviour.Instance.SpikeBlock;

            retGame_spike.GetComponentInChildren<AudioSource>().clip = ManageLevelBehaviour.Instance.Spike;
            retGame_spike.GetComponentInChildren<AudioSource>().playOnAwake = false;

            return retGame_spike;

        }

        int rand_i = (int)Random.Range(0, ManageLevelBehaviour.Instance.BlockColor.Count);

        GameObject retGame = ManageLevelBehaviour.Instance.BaseLevelBlock;

        retGame.GetComponent<SpriteRenderer>().color = ManageLevelBehaviour.Instance.BlockColor[rand_i];
        retGame.GetComponent<AudioSource>().clip = ManageLevelBehaviour.Instance.BaseBlockAudio;
        retGame.GetComponent<AudioSource>().playOnAwake = false;

        return retGame;

    }

    
}
