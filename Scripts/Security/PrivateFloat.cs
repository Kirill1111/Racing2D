using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Private 
{

    private double offset;
    private double value;

    #region constructions
    public Private(float value)
    {
        offset = new  System.Random().Next(-10000, 10000);
        this.value = value + offset;
    }
    public Private(double value)
    {
        offset = new System.Random().Next(-10000, 10000);
        this.value = value + offset;
    }
    public Private(int value)
    {
        offset = new System.Random().Next(-10000, 10000);
        this.value = value + offset;
    }
    public Private(byte value)
    {
        offset = new System.Random().Next(-10000, 10000);
        this.value = value + offset;
    }
    #endregion

    public double GetValue()
    {
        return value - offset;
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }



    #region operations

    public static implicit operator Private(double value)
    {
        return new Private(value);
    }

    public static implicit operator Private(float value)
    {
        return new Private(value);
    }

    public static implicit operator Private(int value)
    {
        return new Private(value);
    }

    public static implicit operator Private(byte value)
    {
        return new Private(value);
    }

    public static implicit operator double(Private value)
    {
        return value.GetValue();
    }

    public static implicit operator float(Private value)
    {
        return new Private(value);
    }

    public static implicit operator int(Private value)
    {
        return new Private(value);
    }

    public static implicit operator byte(Private value)
    {
        return new Private(value);
    }

    public static Private operator -(Private double1, Private double2)
    {
        return new Private(double1.GetValue() - double2.GetValue());
    }
    public static Private operator +(Private double1, Private double2)
    {
        return new Private(double1.GetValue() + double2.GetValue());
    }
    public static Private operator *(Private double1, Private double2)
    {
        return new Private(double1.GetValue() * double2.GetValue());
    }
    public static Private operator /(Private double1, Private double2)
    {
        return new Private(double1.GetValue() / double2.GetValue());
    }
    public static bool operator >=(Private double1, Private double2)
    {
        if (double1.GetValue() >= double2.GetValue())
            return true;
        return false;
    }
    public static bool operator <=(Private double1, Private double2)
    {
        if (double1.GetValue() <= double2.GetValue())
            return true;
        return false;
    }

    public static bool operator ==(Private double1, Private double2)
    {
        if (double1.GetValue() == double2.GetValue())
            return true;
        return false;
    }
    public static bool operator !=(Private double1, Private double2)
    {
        if (double1.GetValue() != double2.GetValue())
            return true;
        return false;
    }

    public static Private operator ++(Private double1)
    {
        double Result = double1.GetValue();
        return new Private(Result++);
    }
    public static Private operator --(Private double1)
    {
        double Result = double1.GetValue();
        return new Private(Result--);
    }

    #endregion


}
