using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    [SerializeField] private SettingManager settingPanel;
    [SerializeField] private Roulette roulette;
    
    [SerializeField] private Button settingButton;
    [SerializeField] private Button rotaterButton;

    [SerializeField] private Button initButton;
    [SerializeField] private GameObject rouletteSettingPrefab;

    void Start()
    {
        initButton.onClick.AddListener(InitializeRoulette);
        settingButton.onClick.AddListener(() => settingPanel.gameObject.SetActive(true));
    }

    private void InitializeRoulette()
    {
        Debug.Log("Initialize Roulette");
        RouletteSettingPanel rouletteSettingPanel = UIStack.Push<RouletteSettingPanel>(rouletteSettingPrefab);
    }
}
