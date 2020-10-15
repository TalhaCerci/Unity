using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class demirMiktar : MonoBehaviour
{
    private string[] Lines;
    void Start()
    { }   
    void Update()
    {
        //Bu script içerisinde users içinden aktif kullanıcının Demirmiktarı değerini anlık olarak Demirmiktar butonuna yazdırıyoruz
         Lines = System.IO.File.ReadAllLines("users.txt");
         string veri = "";
         for (int i = 0; i <Lines.Length; i++)
         {
             string[] bilgiler = Lines[i].Split(' ');
             if (bilgiler[0] == "1")
             {
                 veri = bilgiler[7];
                 break;
             }
         }
         GameObject.Find("Demirmiktar").GetComponentInChildren<Text>().text = veri;
    }
}