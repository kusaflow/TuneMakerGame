using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevelBehaviour : MonoBehaviour
{
    public int SpikeRateOutOf100 = 10;

    [Space]
    public List<AudioClip> BlockAudioClips = new List<AudioClip>();
    public AudioClip Spike;

    [Space]
    public List<Color> BlockColor = new List<Color>();

}
