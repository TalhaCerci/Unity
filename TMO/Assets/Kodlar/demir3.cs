using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class demir3 : MonoBehaviour
{
    private string[] Lines;
    

    void Start()
    {
      }
    public void tiklandi()
    {
        SceneManager.LoadScene("DemirMadeni3");
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
                 veri = bilgiler[12];
                 break;
             }
         }

         GameObject.Find("Demir3").GetComponentInChildren<Text>().text = veri;
    
    
    }
}
