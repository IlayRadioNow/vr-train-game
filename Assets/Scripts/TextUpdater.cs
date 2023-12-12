using System;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _text1, _hpText1;
    [SerializeField] private GameObject _winPanel, _losePanel;

    private static TMP_Text _text,_hpText;

    private void Awake()
    {
        _text = _text1;
        _hpText = _hpText1; 
    }
    public static void UpdateText()
    {
        _text.text = (Convert.ToInt32(_text.text)+1).ToString();
    }

    public static void UpdateHPText()
    {
        print("updateHP");
        _hpText.text = (Convert.ToInt32(_hpText.text) - 1).ToString();
    }

    private void Update()
    {
        if (Convert.ToInt32(_hpText)< 1) 
        {
            _losePanel.SetActive(true);        
        }
        else if (Convert.ToInt32(_text) > 4)
        {
            _winPanel.SetActive(true);
        }
    }
}
