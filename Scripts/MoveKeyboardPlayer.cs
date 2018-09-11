

using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class MoveKeyboardPlayer : Photon.MonoBehaviour
{

    // Переменные движения
    public GameObject player;
    public Private speedRotation = 7;
    public Private speed = 0;
    public Private MinSpeed;
    public Private speedAcceleration;
    public Private MaxSpeed = 60;
    public Private speeD = 3;

    public GameObject cam;
    public GameObject MobileControl;
    public GameObject Timer;
    public Sprite[] Car;
    public int CarType = 0;

    public bool MobileControl1 = false;
    public bool MobileControl2 = false;
    public bool MobileControl3 = false;
    public bool MobileControl4 = false;

    private RigidbodyConstraints standart;
    private bool OnCol = false;
    private Rigidbody CamRB;
    private Rigidbody rb;
    private AudioSource carAudio;
    private bool run = true;
    private bool KeyDown = true;
    private Vector3 oldPos = Vector3.zero;
    private Vector3 newPos = Vector3.zero;
    private Quaternion oldQua = Quaternion.identity;
    private Quaternion newQua = Quaternion.identity;
    float offSetTime = 0;
    bool isSinch = false;

    public void OnPointerDown1(Boolean Action)
    {

            Informations.MobileControl1 = Action;
        
    }
    public void OnPointerDown2(Boolean Action)
    {

            Informations.MobileControl2 = Action;
        
    }
    public void OnPointerDown3(Boolean Action)
    {

            Informations.MobileControl3 = Action;
        
    }
    public void OnPointerDown4(Boolean Action)
    {
            Informations.MobileControl4 = Action;
        
    }

    void Start()
    {
            carAudio = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
           standart = rb.constraints;
 
            player = this.gameObject;

        if (Informations.isNet)
        {
            cam = GameObject.Find("Main Camera");
            MobileControl = GameObject.Find("MobileControl");
            if(photonView.isMine)
            cam.SetActive(photonView);
        }

        if (Informations.isNet && photonView.isMine)
            photonView.RPC("SelectColor", PhotonTargets.AllBuffered, Informations.CarId);
        else if (!Informations.isNet)
            SelectColor(Informations.CarId);

            if (Application.platform == RuntimePlatform.WindowsPlayer || Informations.isDebug)
                Destroy(MobileControl);


            CamRB = cam.GetComponent<Rigidbody>();

    }


    [PunRPC]
    public void SelectColor(int CarID)
    {
                GetComponent<SpriteRenderer>().sprite = Car[CarID];

        switch (CarID)
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

    }



    private void Update()
    {

        carAudio.pitch = Mathf.Clamp((float)speed / 15, 0.1f, 4f);


        if (photonView.isMine || !Informations.isNet)
        {

            cam.transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            rb.velocity = -player.transform.up * (float)speed * Time.deltaTime * 35;

            if (Informations.isStart == true || Informations.isNet)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Informations.MobileControl1)
                {
                    if ((float)speed < (float)MaxSpeed && (float)speed + (float)speeD * Time.deltaTime < (float)MaxSpeed)
                    {
                        speed += speedAcceleration * Time.deltaTime;
                        run = true;
                        KeyDown = true;
                    }
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Informations.MobileControl3)
                {
                    if ((float)speed > (float)MinSpeed && (float)speed - (float)speeD * Time.deltaTime > (float)MinSpeed)
                    {
                        if (speed >= 0)
                            speed -= speeD * Time.deltaTime * speeD;
                        else
                            speed -= speeD * Time.deltaTime * speeD / 3;
                        run = false;
                        KeyDown = true;
                    }
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Informations.MobileControl4)
                {
                    if (speed == 0) return;
                    speed -= speeD * Time.deltaTime * speed / MaxSpeed * 3.5f;
                    if (run || speed > 0)
                        player.transform.localEulerAngles += Vector3.back * (float)speedRotation * Time.deltaTime;
                    else
                        player.transform.localEulerAngles += Vector3.forward * (float)speedRotation * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Informations.MobileControl2)
                {
                    if (speed == 0) return;
                    speed -= speeD * Time.deltaTime * speed / MaxSpeed * 3;
                    if (run || speed > 0)
                        player.transform.localEulerAngles += Vector3.forward * (float)speedRotation * Time.deltaTime;
                    else
                        player.transform.localEulerAngles += Vector3.back * (float)speedRotation * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.Escape))
                {
                    Application.Quit();
                }

                if (KeyDown == false)
                {
                    if (speed >= 0)
                    {
                        if (speed - speeD * Time.deltaTime > 0)
                            speed -= speeD * Time.deltaTime;
                        else
                        {
                            speed = 0;
                            run = true;
                        }
                    }
                    else
                    {
                        if (speed + speeD * Time.deltaTime < 0)
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
        }
        else if (isSinch)
        {

            offSetTime = Time.deltaTime * 6f;

            rb.transform.position = Vector3.Lerp(transform.position, newPos, offSetTime);

            rb.rotation = Quaternion.Lerp(transform.rotation, newQua, offSetTime);
        }

    }
    

    private void OnCollisionExit(Collision collision)
    {
        if (photonView.isMine||!Informations.isNet)
            rb.freezeRotation = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(photonView.isMine||!Informations.isNet)
        rb.constraints = standart;
    }

    private void OnCollisionStay(Collision collision)
    {
      /*  if(speed >=0)
         speed -= speeD * Time.deltaTime * speeD;    */   
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        stream.Serialize(ref pos);
        stream.Serialize(ref rot);
        if (stream.isReading)
        {
            oldPos = rb.position;
            newPos = pos;
            oldQua = rb.rotation;
            newQua = rot;

            offSetTime = 0;
            isSinch = true;
        }
    }

}
