using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    public string countryName;
    public float low;
    public float medium;
    public float high;

    public Country(string aName, float aLow, float aMedium, float aHigh){
        countryName = aName;
        low = aLow;
        medium = aMedium;
        high = aHigh;
    }
}
