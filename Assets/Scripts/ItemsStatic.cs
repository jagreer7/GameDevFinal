using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemsStatic
{

    static bool cookie1Collected = false;
    static bool cookie2Collected = false;
    static bool cookie3Collected = false;
    static bool filamentCollected = false;
    static bool solderCollected = false;
    static bool electronicCollected = false;
    static bool instructionsCollected = false;
    static bool ATLASKey0Collected = false;
    static bool ATLASKey1Collected = false;
    static bool ATLASKey2Collected = false;
    static bool ATLASKey3Collected = false;
    public static bool checkIfCollected(int id)
    {
        if (id == 1) //Cookie 1
        {
            return cookie1Collected;
        }
        else if (id == 2) //Cookie 2
        {
            return cookie2Collected;
        }
        else if (id == 3) //Cookie 3
        {
            return cookie3Collected;
        }
        else if (id == 4) //Filament
        {
            return filamentCollected;
        }
        else if (id == 5) //Solder
        {
            return solderCollected;
        }
        else if (id == 6) //Electronic
        {
            return electronicCollected;
        }
        else if (id == 7) //Intsructions
        {
            return instructionsCollected;
        }
        else if (id == 8) //Key 0
        {
            return ATLASKey0Collected;
        }
        else if (id == 9) //Key 1
        {
            return ATLASKey1Collected;
        }
        else if (id == 10) //Key 2
        {
            return ATLASKey2Collected;
        }
        else if (id == 11) //Key 3
        {
            return ATLASKey3Collected;
        }
        else
        {
            return false;
        }
    }
    public static void setCollected(int id)
    {
        if (id == 1) //Cookie 1
        {
            cookie1Collected = true;
        }
        else if (id == 2) //Cookie 2
        {
            cookie2Collected = true;
        }
        else if (id == 3) //Cookie 4
        {
            cookie3Collected = true;
        }
        else if (id == 4) //Filament
        {
            filamentCollected = true;
        }
        else if (id == 5) //Solder
        {
            solderCollected = true;
        }
        else if (id == 6) //Electronic
        {
            electronicCollected = true;
        }
        else if (id == 7) //Instructions
        {
            instructionsCollected = true;
        }
        else if (id == 8) //Key 0
        {
            ATLASKey0Collected = true;
        }
        else if (id == 9) // Key 1
        {
            ATLASKey1Collected = true;
        }
        else if (id == 10) //Key 2
        {
            Debug.Log("Key acquired");
            ATLASKey2Collected = true;
        }
        else if (id == 11) //Key3
        {
            ATLASKey3Collected = true;
        }
    }

    //For Traded items
    static bool cookie1Traded = false;
    static bool cookie2Traded = false;
    static bool cookie3Traded = false;
    static bool electronicTraded = false;
    static bool filamentTraded = false;
    static bool instructionsTraded = false;
    public static bool checkIfTraded(int id)
    {
        if (id == 1) //Cookie 1
        {
            return cookie1Traded;
        }
        else if (id == 2) //Cookie 2
        {
            return cookie2Traded;
        }
        else if (id == 3) //Cookie 3
        {
            return cookie3Traded;
        }
        else if (id == 6) //Electronic
        {
            return electronicTraded;
        }
        else if (id == 4) //filament
        {
            return filamentTraded;
        }
        else if (id == 7) //Instructions
        {
            return instructionsTraded;
        }
        else
        {
            return false;
        }
    }

    public static void setTraded(int id)
    {
        if (id == 1) //Cookie 1
        {
            cookie1Traded = true;
        }
        else if (id == 2) //Cookie 2
        {
            cookie2Traded = true;
        }
        else if (id == 3) //Cookie 4
        {
            cookie3Traded = true;
        }
        else if (id == 6) //Electronic
        {
            electronicTraded = true;
        }
        else if (id == 4) //Filament
        {
            filamentTraded = true;
        }
        else if (id == 7) //Instructions
        {
            instructionsTraded = true;
        }
    }
}
