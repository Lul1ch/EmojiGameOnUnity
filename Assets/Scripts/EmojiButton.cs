using UnityEngine;
using UnityEngine.UI;

public class EmojiButton : MonoBehaviour
{
    SkinsHolder skinsHolder;
    StateHolder stateHolder;
    [SerializeField] AudioSource audioSource;
    [Header("Sounds")]
    [SerializeField] AudioClip funSound;
    [SerializeField] AudioClip sadSound;
    [SerializeField] AudioClip angrySound;
    [SerializeField] AudioClip crazySound;
    [SerializeField] AudioClip creepySound;

    public enum Mood {
        Fun = 0, Sad, Angry, Crazy, Creepy
    }

    [HideInInspector]
    public Mood emojiMood;

    private void Awake() {
        GameObject holder = GameObject.FindGameObjectWithTag("Holder");
        skinsHolder = holder.GetComponent<SkinsHolder>();
        stateHolder = holder.GetComponent<StateHolder>();
    }

    private void Start() {
        int rand = Random.Range(0, Mood.GetValues(typeof(Mood)).Length);
        emojiMood = (Mood)rand;
        RandSkin();
        Destroy(gameObject, 8f);
    }

    private void RandSkin() {
        Image objImage = gameObject.GetComponent<Image>();
        int rand;
        switch(emojiMood) {
            case Mood.Fun:
            rand = Random.Range(0, skinsHolder.funEmojies.Count);
            objImage.sprite = skinsHolder.funEmojies[rand];
            audioSource.clip = funSound;
            break;

            case Mood.Sad:
            rand = Random.Range(0, skinsHolder.sadEmojies.Count);
            objImage.sprite = skinsHolder.sadEmojies[rand];
            audioSource.clip = sadSound;
            break;

            case Mood.Angry:
            rand = Random.Range(0, skinsHolder.angryEmojies.Count);
            objImage.sprite = skinsHolder.angryEmojies[rand];
            audioSource.clip = angrySound;
            break;

            case Mood.Crazy:
            rand = Random.Range(0, skinsHolder.crazyEmojies.Count);
            objImage.sprite = skinsHolder.crazyEmojies[rand];
            audioSource.clip = crazySound;
            break;

            case Mood.Creepy:
            rand = Random.Range(0, skinsHolder.creepyEmojies.Count);
            objImage.sprite = skinsHolder.creepyEmojies[rand];
            audioSource.clip = creepySound;
            break;
        }
    }

    public void handleClick() {
        stateHolder.handleClick(gameObject);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
