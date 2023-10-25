using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    [SerializeField] Button spinButton;

    private void Start()
    {
        spinButton.onClick.AddListener(Spin);
    }

    private void Spin()
    {
        Debug.Log("Start Spin");
    }

    public void SetData(int typeCount, List<string> typeList)
    {

    }
}
