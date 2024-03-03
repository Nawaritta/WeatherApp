using System;

[Serializable]
public class Location
{
    public string name;
    public string localtime;
}

[Serializable]
public class Condition
{
    public string text;
}

[Serializable]
public class Current
{
    public float temp_c;
    public Condition condition;
    public float wind_kph;
    public float pressure_mb;
    public int humidity;
}

[Serializable]
public class CityData
{
    public Location location;
    public Current current;
}

