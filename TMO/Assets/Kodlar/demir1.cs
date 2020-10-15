using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Threading;

public class demir1 : MonoBehaviour
{
    private string[] Lines;
	//Lines adında private bir String dizisi oluşturuldu
    void Start()
    { }
    public void tiklandi()
    {
		//bu fonksiyon çalıştığı zaman varolan sahneden DemirMadeni1 sahnesine geçiş yapılıyor
        SceneManager.LoadScene("DemirMadeni1");
    }
    void Update()
    { 
		//update işleminde yazılan bu kodlar oyunun her anında çalışıp varolan değişiklikleri anında ekrana yansıtır.
         Lines = System.IO.File.ReadAllLines("users.txt"); //users.txt isimli dosyayı okuyup bütün satırları ayrı ayrı Lines dizisine atar.
         string veri = "";
         for (int i = 0; i <Lines.Length; i++)
         {
              //Lines dizisinin her bir elemanını her bir satırı boşluk karakterine göre parçalara ayırıp bilgiler dizisine atar
             string[] bilgiler = Lines[i].Split(' ');
             if (bilgiler[0] == "1")
             {
				 //bilgiler dizisinin ilk elemanı 1'e eşitse yani o kullanıcı aktifse 
                 //bilgilerin 10. elemanını yani demir1 seviyesini metin belgesinden alıp veri değişkenine atar
                 veri = bilgiler[10];  
                 break;
             }
         }
         GameObject.Find("Demir1").GetComponentInChildren<Text>().text = veri;
		 //GameObject içinden Demir1 isimli nesneyi bulup, bu nesnenin componentlerinden Text'in textine veri değerini yazar 
    }
}