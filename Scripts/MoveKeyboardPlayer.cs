using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class MoveKeyboardPlayer : MonoBehaviour
{

    // Переменные движения
    public GameObject player;
    public Private speedRotation = 7;
    public Private speed = 0;
    public Private MinSpeed;
    public Private speedAcceleration;
    public Private MaxSpeed = 60;
    public Private speeD = 3;
    public Camera cam;
    public GameObject MobileControl;
    public GameObject Timer;
    public Sprite[] Car;

    private Boolean MobileControl1 = false;
    private Boolean MobileControl2 = false;
    private Boolean MobileControl3 = false;
    private Boolean MobileControl4 = false;

    private RigidbodyConstraints standart;
    private bool OnCol = false;
    private Rigidbody CamRB;
    private Rigidbody rb;
    private AudioSource carAudio;
    private bool run = true;
    private bool KeyDown = true;

    public void OnPointerDown1(Boolean Action)
    {
        MobileControl1 = Action;
    }
    public void OnPointerDown2(Boolean Action)
    {
        MobileControl2 = Action;
    }
    public void OnPointerDown3(Boolean Action)
    {
        MobileControl3 = Action;
    }
    public void OnPointerDown4(Boolean Action)
    {
        MobileControl4 = Action;
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Car[Informations.CarId];

        switch (Informations.CarId)
        {
            case 0:
                GetComponent<MoveKeyboardPlayer>().MaxSpeed = 20;
                GetComponent<MoveKeyboardPlayer>().speedAcceleration = 2f;
                GetComponent<MoveKeyboardPlayer>().speeD = 2.5f;
                GetComponent<MoveKeyboardPlayer>().speedRotation = 100;
                GetComponent<MoveKeyboardPlayer>().MinSpeed = -3;
                break;
            case 1:
                GetComponent<MoveKeyboardPlayer>().MaxSpeed = 25;
                GetComponent<MoveKeyboardPlayer>().speedAcceleration = 2.5f;
                GetComponent<MoveKeyboardPlayer>().speeD = 3;
                GetComponent<MoveKeyboardPlayer>().speedRotation = 100;
                GetComponent<MoveKeyboardPlayer>().MinSpeed = -3;
                break;
        }
        if (Application.platform == RuntimePlatform.WindowsPlayer)
            Destroy(MobileControl);
        carAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        player = (GameObject)this.gameObject;
        CamRB = cam.GetComponent<Rigidbody>();
        standart = rb.constraints;
    }

    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        carAudio.pitch = Mathf.Clamp((float)speed.GetValue() / 15, 0.1f, 4f);

        if (Timer.GetComponent<Timer>().isStart == true)
        {
            rb.velocity = -player.transform.up * (float)speed.GetValue() * Time.deltaTime * 35;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || MobileControl1)
            {
                if ((float)speed.GetValue() < (float)MaxSpeed.GetValue() && (float)speed.GetValue() + (float)speeD.GetValue() * Time.deltaTime < (float)MaxSpeed.GetValue())
                {
                    speed += speedAcceleration * Time.deltaTime;
                    run = true;
                    KeyDown = true;
                }
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || MobileControl3)
            {
                if ((float)speed.GetValue() > (float)MinSpeed.GetValue() && (float)speed.GetValue() - (float)speeD.GetValue() * Time.deltaTime > (float)MinSpeed.GetValue())
                {
                    if (speed >= 0)
                        speed -= speeD * Time.deltaTime * speeD;
                    else
                        speed -= speeD * Time.deltaTime * speeD / 3;
                    run = false;
                    KeyDown = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || MobileControl4)
        {
            if (speed == 0) return;
            speed -= speeD.GetValue() * Time.deltaTime * speed.GetValue() / MaxSpeed.GetValue() * 3.5f;
            if (run || (float)speed.GetValue() > 0)
                rb.transform.localEulerAngles += Vector3.back * (float)speedRotation.GetValue() * Time.deltaTime;
            else
                rb.transform.localEulerAngles += Vector3.forward * (float)speedRotation.GetValue() * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || MobileControl2)
        {
            if (speed == 0) return;
            speed -= speeD.GetValue() * Time.deltaTime * speed.GetValue() / MaxSpeed.GetValue() * 3;
            if (run || (float)speed.GetValue() > 0)
                rb.transform.localEulerAngles += Vector3.forward * (float)speedRotation.GetValue() * Time.deltaTime;
            else
                rb.transform.localEulerAngles += Vector3.back * (float)speedRotation.GetValue() * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (KeyDown == false)
        {
            if (speed >= 0)
            {
                if ((float)speed.GetValue() - (float)speeD.GetValue() * Time.deltaTime > 0)
                    speed -= speeD * Time.deltaTime;
                else
                {
                    speed = 0;
                    run = true;
                }
            }
            else
            {
                if ((float)speed.GetValue() + (float)speeD.GetValue() * Time.deltaTime < 0)
                    speed += speeD * Time.deltaTime;
                else
                {
                    speed = 0;
                    run = true;
                }
            }
            return;
        }

        KeyDown = false;

    }   

    private void OnCollisionExit(Collision collision)
    {
        rb.freezeRotation = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.constraints = standart;
    }

    private void OnCollisionStay(Collision collision)
    {
      /*  if(speed >=0)
         speed -= speeD * Time.deltaTime * speeD;    */   
    }

}
