using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTower : MonoBehaviour
{
    public GameObject ButtonUpgrade;
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(0.50f));
    }

    void Update()
    {
        
    }

    public void onClick()
    {
        ButtonUpgrade.GetComponent<Button>().enabled = true;
        ButtonUpgrade.GetComponent<Image>().enabled = true;
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitUntil(() => PlaceTower.towerDragged == true);
        this.GetComponent<Button>().enabled = true;
    }
}
