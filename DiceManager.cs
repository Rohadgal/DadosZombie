using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    Dados[] dadosVerdes = new Dados[6];
    Dados[] dadosAmarillos = new Dados[4];
    Dados[] dadosRojos = new Dados[3];

    Dados[] dadoEleccion = new Dados[3];
    Dados[] dadosConPatas = new Dados[3];

    //colorDado[] dadosElegidos = new colorDado[3];

    enum colorDado {verde, amarillo, rojo};

    // Start is called before the first frame update
    void Start()
    {
        CrearDados();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearDados()
    {
        dadosVerdes = new Dados[6];
        dadosAmarillos = new Dados[4];
        dadosRojos = new Dados[3];

        for (int i = 0; i < dadosVerdes.Length; i++)
        {
            dadosVerdes[i] = new Dados();
            Debug.Log(dadosVerdes[i] + " verdes");
        }

        for (int i = 0; i < dadosAmarillos.Length; i++)
        {
            dadosAmarillos[i] = new Dados();
            Debug.Log(dadosAmarillos[i] + " amarillos");
        }

        for (int i = 0; i < dadosRojos.Length; i++)
        {
            dadosRojos[i] = new Dados();
            Debug.Log(dadosRojos[i] + " rojos");
        }
    }


}
