using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dados 
{
    string color;
    int cerebros;
    int patas;
    int disparo;
    bool isPatas;

    public Dados(string c_color, int c_cerebros, int c_patas, int c_disparo, bool b_patas)
    {
        color = c_color;
        cerebros = c_cerebros;
        patas = c_patas;
        disparo = c_disparo;
        isPatas = b_patas;
    }

    public Dados()
    {

    }

    public bool IsPatas
    {
        get { return isPatas; }
        set { isPatas = value; }
    }

    public string Color
    {
        get { return color;}
    }
}
