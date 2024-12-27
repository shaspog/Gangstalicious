using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTranslations : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TranslationSystem translationSyst;

    public void UpdateText()
    {
        string translatedText = translationSyst.TranslateSentence("Danke!");
        textDisplay.text = translatedText;
    }
}
