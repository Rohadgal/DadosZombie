using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    Dados[] dadosVerdes = new Dados[6];
    Dados[] dadosAmarillos = new Dados[4];
    Dados[] dadosRojos = new Dados[3];

    Dados[] dadoEleccion = new Dados[3];
    Dados[] dadosConPatas = new Dados[0];

    bool turnoJugador = true;
    bool primerTiro = true;
    bool tocaPatas;

    int bancoCerebros;
    int numCerebros;
    int numDisparos;
    int numPatas;

    int iGlobal = 0;

    

    void Start()
    {
        CrearDados(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            if(numPatas > 0)
            {
                turnoJugador = true;
                DadosParaJugar(turnoJugador);
                turnoJugador = false;
            }
            else
            {
                turnoJugador = false;
                Debug.Log("Se acabo tu turno. Presiona N para crear dados para el siguiente jugador.");
            }
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            DetenersePasar();
            CrearDados();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            DetenersePasar();
            CrearDados();
        }
    }

    void DadosParaJugar(bool Jugar)
    {
        if (Jugar)
        {
            ComenzarElegirDado();
        }
    }

    private Dados ElegirDadoVerde()
    {
        Dados dadoVerdeElegido = dadosVerdes[0];
        if (dadosVerdes.Length > 0)
        {
            DecidirCaraDado(3, 4);

            Array.Resize(ref dadosVerdes, dadosVerdes.Length - 1);
            Debug.Log("Dado verde elegido");
        }
        else if (dadosVerdes.Length == 0)
        {
            Debug.Log("Ya no hay dados verdes.");
            int randomNum = UnityEngine.Random.Range(1, 2);
            switch (randomNum)
            {
                case 1: dadoVerdeElegido = ElegirDadoRojo(); Debug.Log("Eleccion emergencias Dentro de verdes"); break;
                case 2: dadoVerdeElegido = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias Dentro de verdes"); break;
            }
        }
        return dadoVerdeElegido;
    }

    private Dados ElegirDadoAmarillo()
    {
        Dados dadoAmarilloElegido = dadosAmarillos[0];
        if (dadosAmarillos.Length > 0)
        {
            DecidirCaraDado(2, 3);

            Array.Resize(ref dadosAmarillos, dadosAmarillos.Length - 1);
            Debug.Log("Dado amarillo elegido");
        }
        else if (dadosAmarillos.Length == 0)
        {
            Debug.Log("Ya no hay dados amarillos.");
            int randomNum = UnityEngine.Random.Range(1, 2);
            switch (randomNum)
            {
                case 1: dadoAmarilloElegido = ElegirDadoVerde(); Debug.Log("Eleccion emergencias Dentro de amarillos"); break;
                case 2: dadoAmarilloElegido = ElegirDadoRojo(); Debug.Log("Eleccion emergencias Dentro de amarillos"); break;
            }
        }
        return dadoAmarilloElegido;
    }

    private Dados ElegirDadoRojo()
    {
        Dados dadoRojoElegido = dadosRojos[0];
        if (dadosRojos.Length > 0)
        {
            DecidirCaraDado(2, 3);

            Array.Resize(ref dadosRojos, dadosRojos.Length - 1);
            Debug.Log("Dado rojo elegido");
        }
        else if (dadosRojos.Length == 0)
        {
            Debug.Log("Ya no hay dados rojos.");
            int randomNum  = UnityEngine.Random.Range(1, 2);
            switch (randomNum)
            {
                case 1: dadoRojoElegido = ElegirDadoVerde(); Debug.Log("Eleccion emergencias Dentro de rojos"); break;
                case 2: dadoRojoElegido = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias Dentro de rojos");  break;
                
            }
        }
        return dadoRojoElegido;
    }

    void ComenzarElegirDado()
    {
        if(primerTiro)
        {
            //int i = 0;
            if (DadosDisponibles() >= 3)
            {
                while (iGlobal < dadoEleccion.Length)
                {
                    int randomNum = UnityEngine.Random.Range(1, 3);
                    switch (randomNum)
                    {
                        case 1:
                            if (dadosVerdes.Length > 0) dadoEleccion[iGlobal] = ElegirDadoVerde();
                            else
                            {
                                int randomNume = UnityEngine.Random.Range(1, 2);
                                switch (randomNume)
                                {
                                    case 1: dadoEleccion[iGlobal] = ElegirDadoRojo(); Debug.Log("Eleccion emergencias - Elegir dado verde -rojo"); break;
                                    case 2: dadoEleccion[iGlobal] = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias - Elegir dado verde -amarillo"); break;
                                }
                            }
                            break;

                        case 2:
                            if (dadosAmarillos.Length > 0) dadoEleccion[iGlobal] = ElegirDadoAmarillo();
                            else
                            {
                                int randomNume = UnityEngine.Random.Range(1, 2);
                                switch (randomNume)
                                {
                                    case 1: dadoEleccion[iGlobal] = ElegirDadoRojo(); Debug.Log("Eleccion emergencias - Elegir dado amarillo -rojo"); break;
                                    case 2: dadoEleccion[iGlobal] = ElegirDadoVerde(); Debug.Log("Eleccion emergencias - Elegir dado amarillo -verde"); break;
                                }
                            }
                            break;

                        case 3:
                            if (dadosRojos.Length > 0) dadoEleccion[iGlobal] = ElegirDadoRojo();
                            else
                            {
                                int randomNume = UnityEngine.Random.Range(1, 2);
                                switch (randomNume)
                                {
                                    case 1: dadoEleccion[iGlobal] = ElegirDadoVerde(); Debug.Log("Eleccion emergencias - Elegir dado Rojo -verde"); break;
                                    case 2: dadoEleccion[iGlobal] = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias - Elegir dado Rojo -amarillo"); break;
                                }
                            }
                            break;
                            default: break;
                    }
                    if(tocaPatas)
                    {
                        dadoEleccion[iGlobal].IsPatas = true;
                        tocaPatas = false;
                    }
                    iGlobal++; 
                }
                primerTiro = false;
            }
            else Debug.Log("Ya no hay dados");
        }
        else
        {
            TirarDadosconPatas();
        }
    }

    void CrearDados()
    {
        bancoCerebros = 0;
        numPatas = 0;
        numDisparos = 0;
        numCerebros = 0;

        iGlobal = 0;

        primerTiro = true;

        dadosVerdes = new Dados[6];
        dadosAmarillos = new Dados[4];
        dadosRojos = new Dados[3];

        for (int i = 0; i < dadosVerdes.Length; i++)
        {
            dadosVerdes[i] = new Dados("verde", 3, 2, 1, false);
            Debug.Log(dadosVerdes[i] + " verdes");
        }

        for (int i = 0; i < dadosAmarillos.Length; i++)
        {
            dadosAmarillos[i] = new Dados("amarillo", 2, 2, 2, false);
            Debug.Log(dadosAmarillos[i] + " amarillos");
        }

        for (int i = 0; i < dadosRojos.Length; i++)
        {
            dadosRojos[i] = new Dados("rojo", 1, 2, 3, false);
            Debug.Log(dadosRojos[i] + " rojos");
        }
        turnoJugador = true;
        DadosParaJugar(turnoJugador);
    }

    int DadosDisponibles()
    {
        int dadosDisponibles = 0;

        dadosDisponibles = dadosVerdes.Length + dadosAmarillos.Length + dadosRojos.Length;

        return dadosDisponibles;
    }

    void DecidirCaraDado(int x, int y)
    {
        int rand = UnityEngine.Random.Range(0, 5);
        if (numDisparos < 3)
        {
            if (rand < x)
            {
                numCerebros += 1;
                Debug.Log("Numero de Cerebros = " + numCerebros);
            }
            else if (rand == x || rand == y)
            {   
                numPatas += 1;
                Debug.Log("Numero de Patas = " + numPatas);
                tocaPatas = true;
                
            }
            else if (rand > y)
            {
                numDisparos += 1;
                Debug.Log("Numero Disparos" + numDisparos);
            }
        }
        else
        {
            
            numPatas = 0;
            numDisparos = 0;
            numCerebros = 0;
            Perdiste();
        }
    }

    void Perdiste()
    {
        Debug.Log("Perdiste. Comienza el siguiente jugador");
        turnoJugador = false;
        CrearDados();
    }

    void TirarDadosconPatas()
    {
        int i = 0;
        if (numPatas > 0)
        {
            numPatas = 0;
            primerTiro = false;
            Dados[] tempArray = new Dados[3];
            foreach(Dados opt in dadoEleccion)
            {
                
                if (opt.IsPatas == true)
                {
                    tempArray[i] = SeleccionarDadosSeguirJugando();
                    Debug.Log("Se tiro dado de nuevo");
                    i++;
                }
                else if(opt.IsPatas == false)
                {
                    tempArray[i] = opt;
                    Debug.Log("este dado quedo igual");
                    Debug.Log(tempArray[i].Color);
                    i++;
                }
                
            }
            dadoEleccion = tempArray;
            Debug.Log("Se tiraron dados de nuevo");
        }
        i = 0;
    }

    void DetenersePasar()
    {
        bancoCerebros = numCerebros;
        numDisparos = 0;
        numCerebros = 0;
   
        Debug.Log("Numero de puntos: " + bancoCerebros);
    }

    Dados SeleccionarDadosSeguirJugando()
    {
        Dados n1 = null;
        if (DadosDisponibles() >= 3)
        {

            int randomNum = UnityEngine.Random.Range(1, 3);
            switch (randomNum)
            {
                case 1:
                    if (dadosVerdes.Length > 0) n1 = ElegirDadoVerde();
                    else
                    {
                        int randomNume = UnityEngine.Random.Range(1, 2);
                        switch (randomNume)
                        {
                            case 1: n1 = ElegirDadoRojo(); Debug.Log("Eleccion emergencias - Elegir dado verde -rojo"); break;
                            case 2: n1 = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias - Elegir dado verde -amarillo"); break;
                        }
                    }
                    break;

                case 2:
                    if (dadosAmarillos.Length > 0) n1 = ElegirDadoAmarillo();
                    else
                    {
                        int randomNume = UnityEngine.Random.Range(1, 2);
                        switch (randomNume)
                        {
                            case 1: n1 = ElegirDadoRojo(); Debug.Log("Eleccion emergencias - Elegir dado amarillo -rojo"); break;
                            case 2: n1 = ElegirDadoVerde(); Debug.Log("Eleccion emergencias - Elegir dado amarillo -verde"); break;
                        }
                    }
                    break;

                case 3:
                    if (dadosRojos.Length > 0) n1 = ElegirDadoRojo();
                    else
                    {
                        int randomNume = UnityEngine.Random.Range(1, 2);
                        switch (randomNume)
                        {
                            case 1: n1 = ElegirDadoVerde(); Debug.Log("Eleccion emergencias - Elegir dado Rojo -verde"); break;
                            case 2: n1 = ElegirDadoAmarillo(); Debug.Log("Eleccion emergencias - Elegir dado Rojo -amarillo"); break;
                        }
                    }
                    break;
                default:
                    break;

            }
            Dados nuevaSeleccion = n1;
            return nuevaSeleccion;
        }
        else Debug.Log("YA NO HAY DADOS");

        return n1;

    }
}
