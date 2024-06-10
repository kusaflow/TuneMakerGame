using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScene : MonoBehaviour
{
    public Button popBtn;
    

    // Update is called once per frame
    void Update()
    {
        popBtn.interactable = !globalStatic.DisablePopBtn;   
    }
}
