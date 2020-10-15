using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class odunDepo : MonoBehaviour
{
    private string[] Lines;
    private float startTime;
    private double hesapla = 0;
    private double sonuc = 0; 
    void Start()
    {
         //Start fonksiyonu içerisinde users dosyasından bilgileri okuyup aktif olan kullanıcının odun miktarını alıp private değişken olan
        // sonuc içerisine aktarıyoruz ve timer'ı başlatıyoruz
        Lines = System.IO.File.ReadAllLines("users.txt");
        string veri = "";
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                veri = bilgiler[5];
                break;
            }
        }
        sonuc = Convert.ToDouble(veri);
        startTime = Time.time;
    }
     void Update()
    {
        //update fonksiyonu içinde saatlik üretim değerini odunuretim butonu üzerinde yazan değerden alıp her saniye artması için 
        //bu değeri 3600'e bölüp çıkan sonucu sürekli eski sonuca ekliyoruz ve bu sonucu her değişimde OdunMiktar butonuna yazırıyoruz
        hesapla = Convert.ToDouble(GameObject.Find("odunuretim").GetComponentInChildren<Text>().text);
        hesapla = hesapla / 3600;
        sonuc += hesapla;
        GameObject.Find("Odunmiktar").GetComponentInChildren<Text>().text = sonuc.ToString();
    }
}