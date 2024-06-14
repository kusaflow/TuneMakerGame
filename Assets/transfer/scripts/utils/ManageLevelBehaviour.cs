using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevelBehaviour : MonoBehaviour
{
    public int SpikeRateOutOf100 = 10;

    public static ManageLevelBehaviour Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Space]
    public List<AudioClip> BlockAudioClips = new List<AudioClip>();
    public AudioClip Spike;
    public AudioClip BaseBlockAudio;


    [Space]
    public List<Color> BlockColor = new List<Color>();

    [Space]
    public GameObject BaseLevelBlock;
    public GameObject SpikeBlock;

}
