using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settextactive : MonoBehaviour
{
    public GameObject textbox;

    void Start()
    {
        textbox.SetActive(false);
    }

    public void onClick()
    {
        Destroy(textbox);
    }
}
