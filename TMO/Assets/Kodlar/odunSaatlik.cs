using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class odunSaatlik : MonoBehaviour
{
    private int odun1 = 0;
    private int odun2 = 0;
    private int odun3 = 0;
    private int odun4 = 0;
    private int hesapla = 0;
    void Start()
    { }
    void Update()
    {
        //odunSaatlik scripti içerisinde Odun seviyelerinin yazılı olduğu butonlar üzerinde yazılı olan seviye değerlerini anlık olarak alıp
        //her birinin 100 katının toplamlarını odunuretim isimli saatlik odun üretimini tutan butona yazdırıyoruz        
        odun1 = Convert.ToInt32(GameObject.Find("Odun1").GetComponentInChildren<Text>().text);
        odun2 = Convert.ToInt32(GameObject.Find("Odun2").GetComponentInChildren<Text>().text);
        odun3 = Convert.ToInt32(GameObject.Find("Odun3").GetComponentInChildren<Text>().text);
        odun4 = Convert.ToInt32(GameObject.Find("Odun4").GetComponentInChildren<Text>().text);
        hesapla = odun1 * 100 + odun2 * 100 + odun3 * 100 + odun4 * 100;
        GameObject.Find("odunuretim").GetComponentInChildren<Text>().text = hesapla.ToString();
    }
}