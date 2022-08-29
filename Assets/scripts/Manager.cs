using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Dados[] dadosVerdes = new Dados[6];
    Dados[] dadosAmarillos = new Dados[4];
    Dados[] dadosRojos = new Dados[3];

    Dados[] dadoEleccion = new Dados[3];

    //Dados verde_1;
    //Dados verde_2;
    //Dados verde_3;
    //Dados verde_4;
    //Dados verde_5;
    //Dados verde_6;


    void Start()
    {
        for (int i = 0; i < dadosVerdes.Length; i++)
        {
            dadosVerdes[i] = new Dados("verde", 3, 2, 1);
            Debug.Log(dadosVerdes[i] + " verdes");
        }

        //foreach(Dados dado in dadosAmarillo)
        //{
        //    dado = new Dados("amarillo", 2, 2, 2);
        //}

        for (int i = 0; i < dadosAmarillos.Length; i++)
        {
            dadosAmarillos[i] = new Dados("amarillo", 3, 2, 1);
            Debug.Log(dadosAmarillos[i] + " amarillos");
        }

        for (int i = 0; i < dadosRojos.Length; i++)
        {
            dadosRojos[i] = new Dados("rojo", 3, 2, 1);
            Debug.Log(dadosRojos[i] + " rojos");
        }

        
    }

    void CrearDado(Dados dadoColor)
    {
        int i = 0;
        while(i < dadoEleccion.Length)
        {
            dadoEleccion[i] = dadoColor;
        }
    }
}
