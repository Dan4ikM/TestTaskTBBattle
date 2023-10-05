using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributeUI : MonoBehaviour
{
    [SerializeField] private Image attributeBar;
    [SerializeField] private TMP_Text attributeText;

    public void Initialize(IAttribute attribute, Color bar_color)
    {
        attribute.OnAttributeChanged += Attribute_OnAttributeChanged;
        attributeBar.color = bar_color;
    }
    
    private void UpdateBar(float amount)
    {
        attributeBar.fillAmount = amount;
    }

    private void UpdateText(int value)
    {
        attributeText.text = value.ToString();
    }

    private void Attribute_OnAttributeChanged(object sender, EventArgs e)
    {
        IAttribute attribute = (IAttribute) sender; 
        UpdateBar(attribute.GetAttributeNormalized());
        UpdateText(attribute.GetAttributeValue());
    }
}
