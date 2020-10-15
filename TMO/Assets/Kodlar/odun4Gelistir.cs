using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class odun4Gelistir : MonoBehaviour
{
    private string[] Lines;
    private int seviye;
    private int satir = 0;
    private int deger = 0;
    void Start()
    {

    }
    void Update()
    {
        Lines = System.IO.File.ReadAllLines("users.txt");
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                deger = Convert.ToInt32(bilgiler[17]);
                break;
            }
        }
        GameObject.Find("Odun4Gelistir").GetComponentInChildren<Text>().text = "Bu Seviyeyi Geliştir : " + (deger + 1).ToString();
    }
    public void gelistir()
    {
        Lines = System.IO.File.ReadAllLines("users.txt");
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                seviye = Convert.ToInt32(bilgiler[17]);
                break;
            }
            satir++;
        }
        seviye += 1;
        System.IO.File.WriteAllText("usersYedek.txt", "");
        string[] bilgiler1 = Lines[satir].Split(' ');
        for (int i = 0; i < Lines.Length; i++)
        {
            if (i == satir)
            {
                bilgiler1[17] = seviye.ToString();
                Lines[i] = "";
                for (int j = 0; j < bilgiler1.Length; j++)
                {
                    Lines[i] = Lines[i] + bilgiler1[j] + " ";
                }
            }
            Lines[i] += "\n";
            System.IO.File.AppendAllText("usersYedek.txt", Lines[i]);
        }
        System.IO.File.Delete("users.txt");
        System.IO.File.Move("usersYedek.txt", "users.txt");
        SceneManager.LoadScene("anaSahne");

    }
}
