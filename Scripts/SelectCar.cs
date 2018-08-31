using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCar : MonoBehaviour {

    public Sprite[] sprite;
    public Image ObjectSprite;
    public int NextLvl;
    public int IDCar;
    public int Page = 0;
    public int Type;

    private int Len;

    public void LeftClick()
    {
        if (Page > 0)
        {
            Page--;
            ObjectSprite.sprite = sprite[Page];
        }
    }

    public void RightClick()
    {
        if (Page < Len-1)
        {
            Page++;
            ObjectSprite.sprite = sprite[Page];      
        }
    }

	void Start () {
        Len = sprite.Length ;
        if (Len > 0)
        {
            ObjectSprite.sprite = sprite[Page];
        }
	}
	
	public void Play () {
        SceneManager.LoadScene(NextLvl);
        if(Type==0)
        Informations.CarId = Page;
    }
}
