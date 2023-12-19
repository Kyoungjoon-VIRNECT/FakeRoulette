using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteSpinner : MonoBehaviour
{
    [SerializeField] Button spinButton;

    private float totalRotationTime = 5f;
    private const float reductionCoefficient = 0.996f;
    
    private void Start()
    {
        spinButton?.onClick.AddListener(() => StartCoroutine(Spin()));
    }

    IEnumerator Spin()
    {
        float rotationSpeed = 10.0f;
        float startTime = Time.time;

        while(Time.time - startTime < totalRotationTime)
        {
            rotationSpeed *= reductionCoefficient;

            transform.Rotate(0,0,rotationSpeed);

            //한 프레임 대기
            yield return null;
        }
    }
}
