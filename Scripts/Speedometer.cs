// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;
using System;

public class Speedometer : Photon.MonoBehaviour {

	public float _start; // начальное положение стрелки по оси Z

	public float maxSpeed; // максимальная скорость на спидометре

	public RectTransform arrow; // стрелка спидометра

	public GameObject target; // объект с которого берем скорость

	public float velocity; // текущая реальная скорость объекта

	private float speed;

	void Start () 
	{
        if(Informations.isNet)
            target = GameObject.Find("MyCar(Clone)");

        arrow.localRotation = Quaternion.Euler(0, 0, _start);
	}

	void Update () 
	{
            velocity = (float)target.GetComponent<MoveKeyboardPlayer>().speed.GetValue() * 6;

            if (velocity > maxSpeed) velocity = maxSpeed;
            if (velocity < 0) velocity = Math.Abs(velocity);
            speed = _start - velocity;
            arrow.localRotation = Quaternion.Euler(0, 0, speed);
        
	}
}
