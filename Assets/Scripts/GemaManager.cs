using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemaManager : MonoBehaviour
{
    public void Update()
    {
        Gemas();
    }
    public void Gemas()
    {
        if (transform.childCount==0)
        {
            Debug.Log("Victoria");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
