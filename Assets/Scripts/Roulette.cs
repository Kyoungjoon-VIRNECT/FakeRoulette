using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    [SerializeField] Button spinButton;

    private float totalRotationTime = 3f;

    private void Start()
    {
        spinButton?.onClick.AddListener(() => StartCoroutine(Spin()));
    }

    IEnumerator Spin()
    {
        Debug.Log("kkj run spin");
        float startTime = Time.time;
        float runTime = Time.time - startTime;

        while(Time.time - startTime < totalRotationTime)
        {
            runTime = Time.time - startTime;
            // ȸ�� �ӵ� ��� (SmoothStep �Լ��� ����Ͽ� ���� �� ���� ����)
            float t = Mathf.SmoothStep(0.0f, 1.0f, runTime / totalRotationTime);
            float accelerationSpeed = Mathf.Lerp(100.0f, 500.0f, t);

            float decelerationT = Mathf.SmoothStep(0.0f, 1.0f, Mathf.Clamp01((runTime - (totalRotationTime * 0.7f)) / (totalRotationTime * 0.3f)));
            float decelerationSpeed = Mathf.Lerp(500.0f, 100.0f, decelerationT);

            float rotationSpeed = Mathf.Lerp(accelerationSpeed, decelerationSpeed, t);

            Debug.Log(" rotation sppeed : " + rotationSpeed);
            // ������� ����� ȸ�� ���� ���
            float rotationAmount = rotationSpeed * runTime;

            transform.rotation = Quaternion.Euler(0, 0, -rotationAmount);

            //�� ������ ���
            yield return null;
        }


        // ȸ�� ������ �ʱ�ȭ
        transform.rotation = Quaternion.Euler(0, 0, 0f);
    }

    public void SetData(int typeCount, List<string> typeList)
    {

    }
}
