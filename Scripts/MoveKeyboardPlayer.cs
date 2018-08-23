using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;

public class MoveKeyboardPlayer : MonoBehaviour
{

    // Переменные движения
    public GameObject player;
    public float speedRotation = 7;
    public float speed = 0;
    public float MinSpeed;
    public float speedAcceleration;
    public float MaxSpeed = 60;
    public float speeD = 3;
    public Camera cam;
   public int ButtonID;
    public GameObject MobileControl;
    public GameObject Timer;

    private RigidbodyConstraints standart;
    private bool OnCol = false;
    private Rigidbody CamRB;
    private Rigidbody rb;
    private AudioSource carAudio;
    private bool run = true;
    private bool KeyDown = true;

    public void OnPointerDown1()
    {
        ButtonID = 1;
    }
    public void OnPointerDown2()
    {
        ButtonID = 2;
    }
    public void OnPointerDown3()
    {
        ButtonID = 3;
    }
    public void OnPointerDown4()
    {
        ButtonID = 4;
    }

    public void OnPointerUp()
    {
        ButtonID = 0;
    }

    void Start()
    {
        if (SystemInfo.operatingSystem != "Windows")
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
        carAudio.pitch = Mathf.Clamp(speed / 15, 0.1f, 4f);

        if (Timer.GetComponent<Timer>().isStart == true)
        {
            rb.velocity = -player.transform.up * speed * Time.deltaTime * 35;
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, 10);


            if (OnCol == false)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || ButtonID == 1)
                {
                    if (speed < MaxSpeed && speed + speeD * Time.deltaTime < MaxSpeed)
                    {
                        speed += speedAcceleration * Time.deltaTime;
                        run = true;
                        KeyDown = true;
                    }
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || ButtonID == 3)
                {
                    if (speed > MinSpeed && speed - speeD * Time.deltaTime > MinSpeed)
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
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || ButtonID == 4)
            {
                if (speed == 0) return;
                speed -= speeD * Time.deltaTime * speed / MaxSpeed * 3.5f;
                if (run || speed > 0)
                    rb.transform.localEulerAngles += Vector3.back * speedRotation * Time.deltaTime;
                else
                    rb.transform.localEulerAngles += Vector3.forward * speedRotation * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || ButtonID == 2)
            {
                if (speed == 0) return;
                speed -= speeD * Time.deltaTime * speed / MaxSpeed * 3;
                if (run || speed > 0)
                    rb.transform.localEulerAngles += Vector3.forward * speedRotation * Time.deltaTime;
                else
                    rb.transform.localEulerAngles += Vector3.back * speedRotation * Time.deltaTime;
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
