using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    [SerializeField] Button spinButton;

    private float totalRotationTime = 3f;
    private float initalRotation = 0.0f;
    
    private void Start()
    {
        spinButton?.onClick.AddListener(() => StartCoroutine(Spin()));
    }

    IEnumerator Spin()
    {
        Debug.Log("kkj run spin");
        float startTime = Time.time;

        while(Time.time - startTime < totalRotationTime)
        {
            float runTime = Time.time - startTime;
            float rotationAmount = Mathf.Lerp(0.0f, 360.0f, runTime / totalRotationTime);
            transform.rotation = Quaternion.Euler(0, 0, -rotationAmount);

            //한 프레임 대기
            yield return null;
        }

        // 회전 끝나면 초기화
        transform.rotation = Quaternion.Euler(0, 0, 0f);
    }

    public void SetData(int typeCount, List<string> typeList)
    {

    }
}
