using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading;
public class Kayitoltiklandiğinda : MonoBehaviour
{
    void Start()
    { }
    public void tiklandi ()
    {
        //Kayitoltiklandiğinda.cs scripti giriş sahnesinde eğer bir kullanıcı hesabı yoksa hesap oluşturmak için oluşturulan 
        //register sahnesine geçiş yapmamızı sağlayan butonun işlevini gerçekleştirir 
        SceneManager.LoadScene("Register");
    }
    void Update()
    { }
}