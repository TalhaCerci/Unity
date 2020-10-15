using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class tuglaMiktar : MonoBehaviour
{
    private string[] Lines;
    void Start()
    { }
    public void tiklandi()
    { }
    void Update()
    {
        //Bu script içerisinde users içinden aktif kullanıcının Tuglamiktar değerini anlık olarak Odunmiktar butonuna yazdırıyoruz
         Lines = System.IO.File.ReadAllLines("users.txt");
         string veri = "";
         for (int i = 0; i <Lines.Length; i++)
         {
             string[] bilgiler = Lines[i].Split(' ');
             if (bilgiler[0] == "1")
             {
                 veri = bilgiler[6];
                 break;
             }
         }
         GameObject.Find("Tuglamiktar").GetComponentInChildren<Text>().text = veri;
    }
}