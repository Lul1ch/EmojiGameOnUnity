using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmojiGun : MonoBehaviour
{
    [SerializeField] GameObject emojiTemplate;
    [SerializeField] GameObject parentObject;
    private Coroutine fireEmojiesCoroutine;
    private float waitTime = 1f;

    public enum DifficultyLevel {
        Easy = 1, Medium, Hard
    }

    static private DifficultyLevel difficulty;

    private void Start() {
        if (SceneManager.GetActiveScene().name == "Game") {
            fireEmojiesCoroutine = StartCoroutine("FireEmojies");
            SetWaitTime(difficulty);
        }
    }

    private void SpawnEmoji() {
        float randX = Random.Range(-9f, 9f);
        float yCoord = -6f;
        GameObject newObject = Instantiate(emojiTemplate,new Vector2(randX, yCoord), Quaternion.identity);
        newObject.transform.SetParent(parentObject.transform);
        Fire(newObject);
    }

    private void Fire(GameObject objToFire) {
        float randX, randY;
        if (objToFire.transform.position.x <= 0) {
            randX = Random.Range(0, 5f);
        } else {
            randX = Random.Range(0, -5f);
        }
        randY = Random.Range(1f, 5f);
        float vForce = Random.Range(65f, 100f);
        objToFire.GetComponent<Rigidbody2D>().AddForce(new Vector2(randX, randY) * vForce);
    }

    public void SetDifficulty(DifficultyLevel buttonDifLevel) {
        difficulty = buttonDifLevel;
    }

    private IEnumerator FireEmojies() {
        while(true) {
            SpawnEmoji();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SetWaitTime(DifficultyLevel curDifficulty) {
        if (curDifficulty == DifficultyLevel.Easy) {
            waitTime = 1f;
        } else if (curDifficulty == DifficultyLevel.Medium) {
            waitTime = 0.5f;
        } else if (curDifficulty == DifficultyLevel.Hard) {
            waitTime = 0.2f;
        }   
    }
}
