using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfTheGameHandler : MonoBehaviour
{
    [SerializeField] TMP_Text messageString;
    static public EmojiButton.Mood finalMood;

    private void Start() {
        if (SceneManager.GetActiveScene().name == "EndOfTheGame") {
            ChangeString();
        }
    }

    private void ChangeString() {
        messageString.text = "You are " + finalMood + " today!";
        switch(finalMood) {
            case EmojiButton.Mood.Fun:
            messageString.text += " Ты пришёл на вечеринку с отличным настроением, приятно тебе провести время, друг!";
            break;

            case EmojiButton.Mood.Sad:
            messageString.text += " Не грусти, помни: кто грустит, тот не радуется!";
            break;

            case EmojiButton.Mood.Angry:
            messageString.text += " Зачем злиться, жизнь слишком коротка, чтобы тратить её на злобу!";
            break;

            case EmojiButton.Mood.Crazy:
            messageString.text += " Ты душа вечеринки - пьяные танцы на столе, анекдоты про гвозди, алкоголь - твои друзья на сегодняшний вечер!";
            break;

            case EmojiButton.Mood.Creepy:
            messageString.text += " Вызывайте Ван Хельсинга, на вечеринку пришёл монстр!";
            break;
        }
    }

    public void SetFinalMood(EmojiButton.Mood mood) {
        finalMood = mood;
    } 

}
