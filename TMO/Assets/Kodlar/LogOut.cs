using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class LogOut : MonoBehaviour
{
    private string[] Lines;
    private double tahil = 0;
    private double demir = 0;
    private double odun = 0;
    private double tugla = 0;
    private int tahil1 = 0;
    private int demir1 = 0;
    private int odun1 = 0;
    private int tugla1 = 0;
    void Start()
    { }
    void Update()
    { }
    public void logOut()
    {
        //logOut scripti içinde kullanıcının oyun içinde geldiği değerlerin son halini kaydedip hesabından çıkış yapması sağlanıyor.
        
        odun = Convert.ToDouble(GameObject.Find("Odunmiktar").GetComponentInChildren<Text>().text);
        demir = Convert.ToDouble(GameObject.Find("Demirmiktar").GetComponentInChildren<Text>().text);
        tahil = Convert.ToDouble(GameObject.Find("Tahilmiktar").GetComponentInChildren<Text>().text);
        tugla = Convert.ToDouble(GameObject.Find("Tuglamiktar").GetComponentInChildren<Text>().text);
        odun1 = Convert.ToInt32(odun);
        demir1 = Convert.ToInt32(demir);
        tugla1 = Convert.ToInt32(tugla);
        tahil1 = Convert.ToInt32(tahil);
        Lines = System.IO.File.ReadAllLines("users.txt");
        System.IO.File.WriteAllText("usersYedek.txt", "");
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[i] == "1")
            {
                //hesaptan çıkış yaparken son değerler Butonlar üzerinde yazan değerlerden alındı ve bilgiler dizisinin ilgili alanalarına aktarıldı
                //logOut işleminde kullanıcının pasif duruma geçmesi için bilgilerin ilk elemanında ki değer 0 yapıldı
                bilgiler[0] = "0";
                bilgiler[5] = odun1.ToString();
                bilgiler[6] = tugla1.ToString();
                bilgiler[7] = demir1.ToString();
                bilgiler[9] = tahil1.ToString();
            }
            Lines[i] = "";
            for (int j = 0; j < bilgiler.Length; j++)
            {
                Lines[i] += bilgiler[j] + " ";
            }
            Lines[i] += "\n";
            System.IO.File.AppendAllText("usersYedek.txt", Lines[i]);
        }
        //yapılan tüm değişiklikler ile birlikte users dosyasında ki veriler usersYedek dosyasına yazıldı ve users dosyası silinp
        // usersYedek dosyasının adı users olarka değiştirildi ve son olarak sampleScene sahnesine geçiş yapıldı
        System.IO.File.Delete("users.txt");
        System.IO.File.Move("usersYedek.txt", "users.txt");
        SceneManager.LoadScene("SampleScene");
    }
}
