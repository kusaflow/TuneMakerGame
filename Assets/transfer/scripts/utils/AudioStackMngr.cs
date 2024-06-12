using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioStackMngr : MonoBehaviour
{
    public Queue<AudioClip> stack = new Queue<AudioClip>();

    float TimerToWait = 0;
    float timer = 0;

    public static AudioStackMngr Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;       
        else
            Destroy(gameObject);
        
    }


    private void Update()
    {
        if (stack.Count <= 0)
            return;

        if (timer >= TimerToWait)
        {
            AudioClip clip = stack.Dequeue();

            timer = 0;
            TimerToWait = clip.length;

            AudioSource AudioS = GetComponent<AudioSource>();
            AudioS.clip = clip;
            AudioS.Play();
            
        }
        else
            timer += 1 * Time.deltaTime;

        
    }




}
