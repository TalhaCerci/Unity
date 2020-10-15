using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class Register : MonoBehaviour
{
    //Register.cs scripti içinde yeni kullanıcı kaydı işlemleri yapılıyor.
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    private bool EmailValid = false;
    private string[] Lines;
    private string[] dizi;
    private string[] Characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "y", "z",
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "Z",
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "_",};
    void Start()
    { }
    public void RegisterButton()
    {
        //RegisterButton fonksiyonu Register sahnesinde ki kayıt ol butonuna tıklandığı anda çalışacağı için 
        //burada kayıt olma koşulları ve koşullar sağlandıktan sonra kayıt olma işlemi gerçekleştirildi
        bool UN = true;
        bool EM = false;
        bool PW = false;
        bool CP = false;
        //Username kontrol
        if (Username != "")
        {
            //eğer Username boş değilse InputField'a kullanıcı adı girilmiştir ve burada
            // users dosyası okunarak daha önce yazılan isimle bir kullanıcı adı oluşturulup oluşturlmadığı kontrol edilir
            Lines = System.IO.File.ReadAllLines("users.txt");
            for (int i = 0; i < Lines.Length; i++)
            {
                dizi = Lines[i].Split(' ');
                if (dizi[0] == Username)
                {
                    //eğer daha önce aynı isimle bir kullanıcı oluşturulmuşsa UN değişkeni false olarak değiştirilir 
                    UN = false;
                    break;
                }
            }
        }
        //e-Mail Kontrol
        if (Email != "")
        {
            //eğer InputField'a veri girişi yapıldıysa e-Mail kontrol işlemleri yapılmaya başlanır 
            EmailValidation();
            if (EmailValid)
            {
                if (Email.Contains("@"))
                {
                    //e-Mail içinde @ simgesinin ve . işaretinin  olup olmadığı kontrol edilir 
                    //bu kontroller sonucu girilen e-Mail değerinde hata yoksa EM değişkeni true olarak değiştirilir
                    if (Email.Contains("."))  EM = true;
                    else  Debug.LogWarning("Email is Incoreect");
                }
                else  Debug.LogWarning("Email is Incorrect");
            }
            else  Debug.LogWarning("Email İs Incorrect");
        }
        else  Debug.LogWarning("Email Field Empty");
        //password Kontrol
        if (Password != "")
        {
           //eğer InputField'a veri girişi yapıldıysa e-Mail kontrol işlemleri yapılmaya başlanır 
           //girilen password değerinin en az 6 karakterden oluşması beklenir eğer koşula uygun girildiyse 
           //PW değişkeninin değeri true olarak değiştirilir
            if (Password.Length > 5) PW = true;
            else  Debug.LogWarning("Password Must Be Atleast 6 Characters long");
        }
        else  Debug.LogWarning("Password Field Empty");
        //password Tekrar Kontrolü
        if (ConfPassword != "")
        {
            //eğer InputFiel'a girilen değer Password değeri ile aynı ise girilen iki password değeri eşittir ve CP değişkeni true olarak değiştirilir
            if (ConfPassword == Password) CP = true;
            else Debug.LogWarning("Passwords Don't Match");
        }
        else
            Debug.LogWarning("Confirm Password Field Empty");
        if (UN == true && EM == true && CP == true)
        {
            //giriş değerleri ile ilgili tüm kontroller bittikten sonra oradan gelen tüm değerler true ise artık kayıt işlemi gerçekleştirilebilir
            bool Clear = true;
            int i = 1;
            //users dosyasına yeni kayıt değerleri ile birlikte yazacağımız oyunun tüm başlangıç değerlerini 
            //aralarında birer boşluk bırakarak form değişkeni içine atıyoruz ve ve bu değişkenin değerlerini users dosyasına ekliyoruz
            form = (0 + " " + Username + " " + Email + " " + Password + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + 0 + " " + Environment.NewLine);
            System.IO.File.AppendAllText("users.txt", form);
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confpassword.GetComponent<InputField>().text = "";
            print("Registration Complete");
            //son olarak bu sahnede kullanılan InputField içinde ki değerleri silip oyunu SampleScene sahnesine yönlendiriyoruz
            SceneManager.LoadScene("SampleScene");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))   // TAB TUŞU İÇİN YAPTIM
        {
            if (username.GetComponent<InputField>().isFocused)
               email.GetComponent<InputField>().Select();
            if (email.GetComponent<InputField>().isFocused)
                password.GetComponent<InputField>().Select();
            if (password.GetComponent<InputField>().isFocused)
                confpassword.GetComponent<InputField>().Select();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Email != "" && Password != "" && ConfPassword != "")
                RegisterButton();
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confpassword.GetComponent<InputField>().text;
    }
    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))  SW = true;
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))  EW = true;
        }
        if (SW == true && EW == true)  EmailValid = true;
        else  EmailValid = false;
    }
}
