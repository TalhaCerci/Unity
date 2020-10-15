using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class iptal : MonoBehaviour
{
    void Start()
    { }
    public void iptal_tiklandi()
    {
        //iptal.cs scripti kayıt sahnesinde kayıt olmaktan vazgeçildiği takdirde
        // giriş işlemi yaptığımız SampleScene sahnesine geçiş yapmamızı sağlar. 
        SceneManager.LoadScene("SampleScene");
    }
    void Update()
    { }
}