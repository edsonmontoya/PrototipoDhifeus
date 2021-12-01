using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdisteAlMenu : MonoBehaviour
{
    public void cuandoQuieroIrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
