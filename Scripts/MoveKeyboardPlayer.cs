

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
<<<<<<< HEAD
    public GameObject cam;
    public GameObject MobileControl;
    public GameObject Timer;
    public Sprite[] Car;
    public int CarType = 0;

    public bool MobileControl1 = false;
    public bool MobileControl2 = false;
    public bool MobileControl3 = false;
    public bool MobileControl4 = false;
=======
    public Camera cam;
    public GameObject MobileControl;
    public GameObject Timer;
    public Sprite[] Car;

    private Boolean MobileControl1 = false;
    private Boolean MobileControl2 = false;
    private Boolean MobileControl3 = false;
    private Boolean MobileControl4 = false;
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6

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
<<<<<<< HEAD

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

            cam = GameObject.Find("Main Camera");
            MobileControl = GameObject.Find("MobileControl");

        if (Informations.isNet)
            photonView.RPC("SelectColor", PhotonTargets.All);
        else
            SelectColor();

            if (Application.platform == RuntimePlatform.WindowsPlayer)
                Destroy(MobileControl);


            CamRB = cam.GetComponent<Rigidbody>();

=======
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
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6
    }

    [PunRPC]
    public void SelectColor()
    {
<<<<<<< HEAD
        int CarI = 0;
        if(photonView.isMine){ 
                GetComponent<SpriteRenderer>().sprite = Car[CarType];
                CarI = CarType;
            }
        else{
                GetComponent<SpriteRenderer>().sprite = Car[Informations.CarId];
            CarI = Informations.CarId;
            }
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

        
=======
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
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6
    }



    void Update()
    {
<<<<<<< HEAD
        carAudio.pitch = Mathf.Clamp((float)speed / 15, 0.1f, 4f);
=======
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        carAudio.pitch = Mathf.Clamp((float)speed.GetValue() / 15, 0.1f, 4f);
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6

        if (photonView.isMine || !Informations.isNet)
        {
<<<<<<< HEAD
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            rb.velocity = -player.transform.up * (float)speed * Time.deltaTime * 35;

            if (Informations.isStart == true || Informations.isNet)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Informations.MobileControl1)
                {
                    if ((float)speed < (float)MaxSpeed && (float)speed + (float)speeD* Time.deltaTime < (float)MaxSpeed)
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
                    if (run || (float)speed > 0)
                        player.transform.localEulerAngles += Vector3.back * (float)speedRotation* Time.deltaTime;
                    else
                        player.transform.localEulerAngles += Vector3.forward * (float)speedRotation * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Informations.MobileControl2)
                {
                    if (speed == 0) return;
                    speed -= speeD * Time.deltaTime * speed / MaxSpeed * 3;
                    if (run || (float)speed > 0)
                        player.transform.localEulerAngles += Vector3.forward * (float)speedRotation * Time.deltaTime;
                    else
                        player.transform.localEulerAngles += Vector3.back * (float)speedRotation* Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.Escape))
                {
                    Application.Quit();
                }

                if (KeyDown == false)
                {
                    if (speed >= 0)
                    {
                        if ((float)speed - (float)speeD * Time.deltaTime > 0)
                            speed -= speeD * Time.deltaTime;
                        else
                        {
                            speed = 0;
                            run = true;
                        }
                    }
                    else
                    {
                        if ((float)speed + (float)speeD * Time.deltaTime < 0)
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
            

=======
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
>>>>>>> 47218e7490fa0b892d001394c4c2c1c4a8f807d6
        }

        KeyDown = false;

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
