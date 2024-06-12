using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickProvider : MonoBehaviour
{

    public GameObject brickPrefab; // Prefab of the brick
    public GameObject Spike;

    int IdxChoosenForBrick = 0;

    ManageLevelBehaviour manageLevelBehaviour;

    private void Start()
    {
        manageLevelBehaviour = FindAnyObjectByType<ManageLevelBehaviour>();
    }

    public GameObject provideBlockToDraw ()
    {

        if (!manageLevelBehaviour)
            manageLevelBehaviour = FindAnyObjectByType<ManageLevelBehaviour> ();
        float rand = Random.Range(0, 100);

        if (rand < manageLevelBehaviour.SpikeRateOutOf100)
            return Spike;

        return brickPrefab;

    }

    //setColor and AudioSource

    public void AddNessPart (GameObject go)
    {
        AudioSource Ads = go.AddComponent<AudioSource>();
        Ads.clip = manageLevelBehaviour.BlockAudioClips[IdxChoosenForBrick];

    }
}
