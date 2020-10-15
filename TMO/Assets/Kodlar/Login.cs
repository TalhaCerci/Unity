using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class Login : MonoBehaviour
{
    //Login.cs scripti kullanıcının oyuna giriş yapabilmesini sağlayan scripttir
    public GameObject username;
    public GameObject password;
    public string Username;
    private string Password;
    private string[] Lines;
    private string form;
    public void LoginButton()
    {
        string yeni = "";
        int satir = 0;
        bool entry = false;
        if (Username != "")
        {
            //Eğer Username boş değilse users.txt dosyasını okuyup içindeki veriler alıyoruz.
            //Username boş ise kullanıcı adı girilmemiştir o yüzden bu kontorlleri yapmak anlamsız olur.
            Lines = System.IO.File.ReadAllLines("users.txt");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] bilgiler = Lines[i].Split(' ');
                if (bilgiler[1] == Username && bilgiler[3] == Password)
                {
                    //Username ve Password değişkenlerinde de tutulan değerler ile users dosyasında ki değerlerin 
                    //eşit olması durumunda entry değişkenin true konumuna getirdik
                    entry = true;
                    break;
                }
                satir++;
            }
        }
        //usersYedek adında yeni bir dosya oluşturduk
        System.IO.File.WriteAllText("usersYedek.txt", "");
        if (entry == true)
        {
            //Eğer entry değişkeninin değeri true ise yani kullanıcı adı ve şifresi doğru ise o kullanıcının kaydının bulunduğu satırın
            // başında ki aktif/pasif değerini tutan alanı 1 yapıp users dosyasında ki tüm verileri güncel hali ile birlikte usersYedek dosyasına yazıyoruz
            string[] bilgiler1 = Lines[satir].Split(' ');
            for (int i = 0; i < Lines.Length; i++)
            {
                if (i == satir)
                {
                    bilgiler1[0] = "1";
                    Lines[i] = "";
                    for (int j = 0; j < bilgiler1.Length; j++)
                    {
                        Lines[i] = Lines[i] + bilgiler1[j] + " ";
                    }
                }
                Lines[i] += "\n";
                System.IO.File.AppendAllText("usersYedek.txt", Lines[i]);
            }
            //users dosyasını silip usersYedk dosyasının adını users olarak değiştiriyoruz.
            System.IO.File.Delete("users.txt");
            System.IO.File.Move("usersYedek.txt", "users.txt");
            //username ve password isminde ki InputField'ların textinde yazan değerleri siliyoruz
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            print("Login Sucessful");
            //giriş işleminde tüm dosya işlemleri tamamlandıktan sonra oyunumuzda anaSahne'ye geçiş yapıyoruz
            SceneManager.LoadScene("anaSahne");
        }
        else if (entry == false)
        {
            //eğer entry değişkeni false ise hatalı girişi consoleda yazıyoruz ve kullanıcı giriş yapamıyoru
            Debug.Log("hatalı giriş");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))   // TAB TUŞU İÇİN YAPTIM
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Username != "" && Password != "")
            {
                LoginButton();
            }
        }
        //String tipindeki Username ve Password değişkenlerine InputField içinde yazan değerler anlık olarak aktarılıyor
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}