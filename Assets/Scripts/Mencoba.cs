using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mencoba : MonoBehaviour
{
    public int bawangMerah = 4;
    public int bawangPutih = 10;
    public float garam = 0.1f;
    public float gula = 0.2f;


    public int potongMenjadiBerapa;

    // Start is called before the first frame update
    void Start()
    {
        PotongBawang(5);

        DebugPrint();
    }


    public void PotongBawang(int jumlah)
    {
        bawangMerah = bawangMerah * jumlah;
        bawangPutih *= jumlah;

    }

    public void DebugPrint()
    {
        Debug.Log("Jumlah Bawang Merah = " + bawangMerah);
        Debug.Log("Jumlah Bawang Putih = " + bawangPutih);
        Debug.Log("Jumlah Garam = " + garam + "gram");
        Debug.Log("Jumlah Gula = " + gula + "gram");
    }
}
