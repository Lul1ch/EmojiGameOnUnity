using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{
    [SerializeField] private EmojiGun.DifficultyLevel buttonDifLevel;
    [SerializeField] private EmojiGun emojiGunScript;
    static private GameObject prevButton;
    
    public void HandleTheClick() {
        if (prevButton != null) {
            prevButton.GetComponent<Image>().color = Color.white;
        }

        gameObject.GetComponent<Image>().color = Color.green;
        prevButton = gameObject;
        emojiGunScript.SetDifficulty(buttonDifLevel);
    } 
}
