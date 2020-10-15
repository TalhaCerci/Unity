using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class demirSaatlik : MonoBehaviour
{
    private int demir1 = 0;
    private int demir2 = 0;
    private int demir3 = 0;
    private int demir4 = 0;
    private int hesapla = 0;
    void Start()
    { }
    void Update()
    {
        //demirSaatlik scripti içerisinde Demir seviyelerinin yazılı olduğu butonlar üzerinde yazılı olan seviye değerlerini anlık olarak alıp
        // her birinin 100 katının toplamlarını demiruretim isimli saatlik demir üretimini tutan butona yazdırıyoruz
        demir1 = Convert.ToInt32(GameObject.Find("Demir1").GetComponentInChildren<Text>().text);
        demir2 = Convert.ToInt32(GameObject.Find("Demir2").GetComponentInChildren<Text>().text);
        demir3 = Convert.ToInt32(GameObject.Find("Demir3").GetComponentInChildren<Text>().text);
        demir4 = Convert.ToInt32(GameObject.Find("Demir4").GetComponentInChildren<Text>().text);
        hesapla = demir1 * 100 + demir2 * 100 + demir3 * 100 + demir4 * 100;
        GameObject.Find("demiruretim").GetComponentInChildren<Text>().text = hesapla.ToString();
    }
}