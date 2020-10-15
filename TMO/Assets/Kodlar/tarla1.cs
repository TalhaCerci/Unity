using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class tarla1 : MonoBehaviour
{
    private string[] Lines;
    void Start()
    { }
    public void tiklandi()
    {
        SceneManager.LoadScene("Tarla1");
	    //bu fonksiyon çalıştığı zaman varolan sahneden Tarla1 sahnesine geçiş yapılıyor
    }
    void Update()
    {
         Lines = System.IO.File.ReadAllLines("users.txt");
         string veri = "";
         for (int i = 0; i <Lines.Length; i++)
         {
             string[] bilgiler = Lines[i].Split(' ');
             if (bilgiler[0] == "1")
             {
                  //bilgiler dizisinin ilk elemanı 1'e eşitse yani o kullanıcı aktifse 
                  //bilgilerin 22. elemanını yani tarla1 seviyesini metin belgesinden alıp veri değişkenine atar
                 veri = bilgiler[22];
                 break;
             }
         }
         GameObject.Find("Tarla1").GetComponentInChildren<Text>().text = veri;
        //GameObject içinden Tarla1 isimli nesneyi bulup, bu nesnenin componentlerinden Text'in textine veri değerini yazar 
    }
}