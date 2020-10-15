using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class tarla2 : MonoBehaviour
{
    private string[] Lines;


    void Start()
    {
    }
    public void tiklandi()
    {

        SceneManager.LoadScene("Tarla2");
    }
    void Update()
    {
        Lines = System.IO.File.ReadAllLines("users.txt");
        string veri = "";
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                veri = bilgiler[23];
                break;
            }
        }

        GameObject.Find("Tarla2").GetComponentInChildren<Text>().text = veri;


    }
}
