using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class tuglaSaatlik : MonoBehaviour
{
    private int tugla1 = 0;
    private int tugla2 = 0;
    private int tugla3 = 0;
    private int tugla4 = 0;
    private int hesapla = 0;
    void Start()
    { }
    void Update()
    {
        //tuglaSaatlik scripti içerisinde Tugla seviyelerinin yazılı olduğu butonlar üzerinde yazılı olan seviye değerlerini anlık olarak alıp
        //her birinin 100 katının toplamlarını tuglauretim isimli saatlik odun üretimini tutan butona yazdırıyoruz    
        tugla1 = Convert.ToInt32(GameObject.Find("Tugla1").GetComponentInChildren<Text>().text);
        tugla2 = Convert.ToInt32(GameObject.Find("Tugla2").GetComponentInChildren<Text>().text);
        tugla3 = Convert.ToInt32(GameObject.Find("Tugla3").GetComponentInChildren<Text>().text);
        tugla4 = Convert.ToInt32(GameObject.Find("Tugla4").GetComponentInChildren<Text>().text);
        hesapla = tugla1 * 100 + tugla2 * 100 + tugla3 * 100 + tugla4 * 100;
        GameObject.Find("tuglauretim").GetComponentInChildren<Text>().text = hesapla.ToString();
    }
}