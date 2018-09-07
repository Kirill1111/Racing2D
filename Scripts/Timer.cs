using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int startTime;
    public GameObject Timer1;
    public GameObject TimerStart;
    public bool isStart = true;
    public GameObject Car;

    private int TimeStart;
    public int time ;

	// Use this for initialization
	void Start () {
        Informations.isNet = false;

        TimeStart = 3;
        InvokeRepeating("StartTime", 0, 1);
        time = startTime;
        InvokeRepeating("Time", TimeStart, 1);
    }

    void StartTime()
    {

        if (TimeStart == -1)
        {
            TimerStart.GetComponent<Text>().text = "";
        }
        if (TimeStart == 0)
        {
            TimerStart.GetComponent<Text>().text = "Start!";
        }
        if (TimeStart > 0)
        {
            TimerStart.GetComponent<Text>().text = TimeStart.ToString();
        }
        TimeStart--;
    }

    void Time () {
        if (Car.GetComponent<Points>().isFinish == true)
        {
            if(time>0)
            TimerStart.GetComponent<Text>().text = "Вы победили";
            time = -1;
            Invoke("LoadScene", 5);
        }
        if (time > 0)
        {         
            time--;
<<<<<<< HEAD
            Informations. isStart = true;
=======
            isStart = true;
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6
            Timer1.GetComponent<Text>().text = time.ToString();
        }
        if (time == 0)
        {
            Timer1.GetComponent<Text>().text = "";
            isStart = true;
            if (Car.GetComponent<Points>().isFinish != true)
            {
                TimerStart.GetComponent<Text>().text = "Вы проиграли";
<<<<<<< HEAD
                Informations.isStart = false;
=======
                isStart = false;
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6
                Invoke("LoadScene",5);
            }
            else
            {
                TimerStart.GetComponent<Text>().text = "Вы победили";
                time = -1;
                Invoke("LoadScene", 5);
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
