using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public int Point;
    public int Finish;
    public bool isFinish = false;
    public int[] PointArr;
    public int FinishID;

    private int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (Count < PointArr.Length)
        {
            if (other.gameObject.layer == PointArr[Count])
            {
                Point++;
                Count++;
            }
        }
        if (other.gameObject.layer == FinishID)
        {
            if (Point >= 3)
                Finish++;
        }
        if (Finish == 1)
        {
            isFinish = true;
        }
    }
}
