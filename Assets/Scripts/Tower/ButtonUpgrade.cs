using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrade : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void onClick()
    {
        this.transform.parent.transform.parent.GetChild(0).gameObject.SetActive(false);
        this.transform.parent.transform.parent.GetChild(1).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
