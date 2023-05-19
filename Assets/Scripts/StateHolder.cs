using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateHolder : MonoBehaviour
{
    static private int funEmojiesCounter, sadEmojiesCounter, angryEmojiesCounter, crazyEmojiesCounter, creepyEmojiesCounter;
    [SerializeField] Image funScale, sadScale, angryScale, crazyScale, creepyScale;
    [SerializeField] private EndOfTheGameHandler endOFTheGameHandler;
    private int countBorder = 20;
    private float countStep = 0.05f;

    private void Start() {
        SetCountersToZero();
    }

    public void handleClick(GameObject curEmoji) {
        
        EmojiButton emojiButton = curEmoji.GetComponent<EmojiButton>();
        curEmoji.GetComponent<AudioSource>().Play();
        switch(emojiButton.emojiMood) {
            case EmojiButton.Mood.Fun: 
            funEmojiesCounter++;
            funScale.fillAmount += countStep;
            CheckForTheEnd(funEmojiesCounter, emojiButton.emojiMood);
            break;

            case EmojiButton.Mood.Sad:
            sadEmojiesCounter++;
            sadScale.fillAmount += countStep;
            CheckForTheEnd(sadEmojiesCounter, emojiButton.emojiMood);
            break;

            case EmojiButton.Mood.Angry:
            angryEmojiesCounter++;
            angryScale.fillAmount += countStep;
            CheckForTheEnd(angryEmojiesCounter, emojiButton.emojiMood);
            break;

            case EmojiButton.Mood.Crazy:
            crazyEmojiesCounter++;
            crazyScale.fillAmount += countStep;
            CheckForTheEnd(crazyEmojiesCounter, emojiButton.emojiMood);
            break;

            case EmojiButton.Mood.Creepy:
            creepyEmojiesCounter++;
            creepyScale.fillAmount += countStep;
            CheckForTheEnd(creepyEmojiesCounter, emojiButton.emojiMood);
            break;
        }
        curEmoji.GetComponent<Image>().enabled =  false;
        Destroy(curEmoji, 1f);
    }


    private void CheckForTheEnd(int counter, EmojiButton.Mood mood) {
        if (counter == countBorder) {
            endOFTheGameHandler.SetFinalMood(mood);
            SceneManager.LoadScene("EndOfTheGame");
        }
    }

    private void SetCountersToZero() {
        funEmojiesCounter = 0;
        sadEmojiesCounter = 0;
        angryEmojiesCounter = 0;
        crazyEmojiesCounter = 0;
        creepyEmojiesCounter = 0;
    }
}
