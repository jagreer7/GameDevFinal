using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public static class MinigameStatic
{
    static bool SolderGameWon = false;

    public static void setSolderingMinigameWon(bool set)
    {
        SolderGameWon = set;
    }
    public static bool getSolderingMinigameWon()
    {
        return SolderGameWon;
    }

    static bool SolderTradeDone = false;
    static bool ElectronicsTradeDone = false;
    static bool AshleyTradeDone = false;
    static bool ThreeDPrinterTradeDone = false; //Doesnt like "3D"
    static bool laserTradeDone = false;
    static bool triangleTradeDone = false;
    public static bool checkIfTradeIsDone(int id)
    {
        if (id == 1) //Solder
        {
            return SolderTradeDone;
        }
        else if (id == 2) //Electronics
        {
            return ElectronicsTradeDone;
        }
        else if (id == 3) //Ashley
        {
            return AshleyTradeDone;
        }
        else if (id == 4) //3DPrinter
        {
            return ThreeDPrinterTradeDone;
        }
        else if (id == 5) //Laser
        {

            return laserTradeDone;
        }
        else if (id == 6) //Triangle
        {

            return triangleTradeDone;
        }
        else
        {
            return false;
        }
    }

    public static void setTradeIsDone(int id)
    {
        if (id == 1) //Solder
        {
            SolderTradeDone = true;
        }
        else if (id == 2) //Electronics
        {
            ElectronicsTradeDone = true;
        }
        else if (id == 3) //Ashley
        {
            AshleyTradeDone = true;
        }
        else if (id == 4) //3DPrinter
        {
            ThreeDPrinterTradeDone = true;
        }
        else if (id == 5) //Laser
        {
            laserTradeDone = true;
        }
        else if (id == 6) //Triangle
        {
            triangleTradeDone = true;
        }
    }

    static bool kitchenUnlock = false;

    public static void setKitchenUnlock(){
      kitchenUnlock = true;
    }

    public static bool getKitchenUnlock(){
      return kitchenUnlock;
    }

    static bool laserUnlock = false;

    public static void setLaserUnlock(){
      laserUnlock = true;
    }

    public static bool getLaserUnlock(){
      return laserUnlock;
    }

    static bool triangleUnlock = false;

    public static void setTriangleUnlock(){
      triangleUnlock = true;
    }

    public static bool getTriangleUnlock(){
      return triangleUnlock;
    }
}
