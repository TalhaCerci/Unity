using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class tahilSaatlik : MonoBehaviour
{
    private int tahil1 = 0;
    private int tahil2 = 0;
    private int tahil3 = 0;
    private int tahil4 = 0;
    private int tahil5 = 0;
    private int tahil6 = 0;
    private int hesapla = 0;
    void Start()
    { }
    void Update()
    {
         //tahilSaatlik scripti içerisinde Tarla seviyelerinin yazılı olduğu butonlar üzerinde yazılı olan seviye değerlerini anlık olarak alıp
        // her birinin 100 katının toplamlarını tahiluretim isimli saatlik tahil üretimini tutan butona yazdırıyoruz
        tahil1 = Convert.ToInt32(GameObject.Find("Tarla1").GetComponentInChildren<Text>().text);
        tahil2 = Convert.ToInt32(GameObject.Find("Tarla2").GetComponentInChildren<Text>().text);
        tahil3 = Convert.ToInt32(GameObject.Find("Tarla3").GetComponentInChildren<Text>().text);
        tahil4 = Convert.ToInt32(GameObject.Find("Tarla4").GetComponentInChildren<Text>().text);
        tahil5 = Convert.ToInt32(GameObject.Find("Tarla5").GetComponentInChildren<Text>().text);
        tahil6 = Convert.ToInt32(GameObject.Find("Tarla6").GetComponentInChildren<Text>().text);
        hesapla = tahil1 * 100 + tahil2 * 100 + tahil3 * 100 + tahil4 * 100 + tahil5 * 100 + tahil6 * 100;
        GameObject.Find("tahiluretim").GetComponentInChildren<Text>().text = hesapla.ToString();
    }
}