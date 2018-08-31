using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    public GameObject[] Tab;
    public Slider GraphicsLevel;

    private int Back = 0;

    public void Chandge(int ID)
    {
        if (Tab.Length > ID)
        {
            if(Back!=null)
            Tab[Back].SetActive(false);
            Tab[ID].SetActive(true);
            Back = ID;
        } else
            throw new System.Exception();
    }

    public void Appli()
    {
        QualitySettings.SetQualityLevel((int)GraphicsLevel.value);
        SceneManager.LoadScene(0);
    }

}