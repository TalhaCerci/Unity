using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading;
public class tugla1Gelistir : MonoBehaviour
{
    private string[] Lines;
    private int seviye;
    private int satir = 0;
    private int deger = 0;
    void Start()
    { }
    void Update()
    {
        Lines = System.IO.File.ReadAllLines("users.txt");
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                deger = Convert.ToInt32(bilgiler[18]);
                break;
            }
        }
        GameObject.Find("Tugla1Gelistir").GetComponentInChildren<Text>().text = "Bu Seviyeyi Geliştir : " + (deger + 1).ToString();
        //bu fonksiyon içerisinde Tugla1'in son seviyesi metin belgesinden okunup 1 fazlası Tugla1Gelistir butonunun text'ine yazıldı
    }
    public void gelistir()
    {
        //gelistir fonksiyonu scriptin içine atılacağı butonun OnClick olayında çalışması için yazıldı
        //user.txt dosyasından tüm satırlar okunup Lines dizisine atıldı aktif olan kullanıcının bilgileri, bilgiler isimli diziye eklendi 
        //içerisinde Tugla1'in seviyesini tutan değer seviye değişkenine atandı
        Lines = System.IO.File.ReadAllLines("users.txt");
        for (int i = 0; i < Lines.Length; i++)
        {
            string[] bilgiler = Lines[i].Split(' ');
            if (bilgiler[0] == "1")
            {
                seviye = Convert.ToInt32(bilgiler[18]);
                break;
            }
            satir++;
        }
        //seviye 1 arttırıldı, usersYedek.txt isimli yeni boş bir dosya oluşturuldu ve güncellenmiş seviye değeri ile birlikte eski bilgiler bu dosyaya yazıldı
        seviye += 1;
        System.IO.File.WriteAllText("usersYedek.txt", "");
        string[] bilgiler1 = Lines[satir].Split(' ');
        for (int i = 0; i < Lines.Length; i++)
        {
            if (i == satir)
            {
                bilgiler1[18] = seviye.ToString();
                Lines[i] = "";
                for (int j = 0; j < bilgiler1.Length; j++)
                {
                    Lines[i] = Lines[i] + bilgiler1[j] + " ";
                }
            }
            Lines[i] += "\n";
            System.IO.File.AppendAllText("usersYedek.txt", Lines[i]);
        }
        //yazma işlemleri bittikten sonra users.txt dosyası silinip usersYedek dosyasının ismi users olarak değiştirildi ve anaSahneye dönüş gerçekleştirildi
        System.IO.File.Delete("users.txt");
        System.IO.File.Move("usersYedek.txt", "users.txt");
        SceneManager.LoadScene("anaSahne");
    }
}