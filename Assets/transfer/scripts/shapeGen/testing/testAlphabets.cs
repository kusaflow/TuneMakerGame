using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAlphabets : MonoBehaviour
{
    public GameObject alpha;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 26; i++)
        {
            //instantiate
            DrawAlphabet drawAlphabet = Instantiate(alpha, new Vector3(i * 4, 0, 0), Quaternion.identity).GetComponent<DrawAlphabet>();
            drawAlphabet.letter = (char)(i + 65);
            //alpha.drawAlphabet((char)(i + 65), new Vector3(i * 2, 0, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
