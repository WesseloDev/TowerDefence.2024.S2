using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUi : MonoBehaviour
{
    public Text text;
    public string cashString = "${0}";

    #region ConnectToAction
    void Start()
    {
        GameManager.cashChanged += UpdateText;
    }

    void OnDestroy()
    {
        GameManager.cashChanged -= UpdateText;
    }
    #endregion

    private void UpdateText(int newCash)
    {
        text.text = string.Format(cashString, newCash);
    }
}
