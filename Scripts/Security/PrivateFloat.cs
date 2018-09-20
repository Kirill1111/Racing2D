/*Данный код необходим для безопасного
 * хранение данных типов float , int ,
 * double. 
 * Разработан : 20 . 09 . 2018
 * Версия кода : 1.0
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Private 
{
    // При создание защищенной переменной генерируется случайный offset
    // После чего к исходному значению пребавляется offset.
    // Например : При создание типа с значением 50 будет сгенерировано
    // случайное число (offset) и к 50 прибавляется offset
    private int offset = 0; // Смещение
    private double value; // Значение

    #region constructions
    public Private(float value)
    {
        Generate();
        this.value = value + offset;
    }
    public Private(double value)
    {
        Generate();
        this.value = value + offset;
    }
    public Private(int value)
    {
        Generate();
        this.value = value + offset;
    }
    public Private(byte value)
    {
        Generate();
        this.value = value + offset;
    }
    #endregion

    private void Generate()
    {
        while (offset == 0)
            offset = new System.Random().Next(-10000, 10000);
        return;
    }

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
        return (float)value.GetValue();
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
