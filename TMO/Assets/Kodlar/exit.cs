using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class exit : MonoBehaviour
{
    void Start()
    { }
    void Update()
    { }
    public void cikis()
    {
        //exit.cs scripti oyundan çıkış yapmak için yazıldı. Exit butonun OnClick eventinde çalıştırlmak üzere 
        //cikis fonksiyonunda Application.Quit(); komutu çalıştırıldı
        Application.Quit();
    }
}