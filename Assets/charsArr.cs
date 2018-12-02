using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charsArr : MonoBehaviour {

    public mainCharControl[] chars;
    public GameObject characterPrefab;
    public Transform pos, ghab1, ghab2;
    public followChar followTargetScript;
    public int charsForLevel;
    public float timeBetweenSpawn = 0.5f;

    int charsToMake;

    private void Start()
    {
        mainCharControl.charArray = this;
        charsToMake = charsForLevel;
        InvokeRepeating("addChar", 0, timeBetweenSpawn);
    }

    void addChar()
    {
        //float i = Random.Range(0, 255);
        //float ii = Random.Range(0, 255);
        //float iii = i > 200 || ii > 200 ? Random.Range(0, 255) : Random.Range(200, 255);
        Color randomColor = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1, 1, 1);
        GameObject char_ = Instantiate(characterPrefab, pos.position, Quaternion.identity, transform);
        char_.GetComponent<SpriteRenderer>().color = randomColor;

        getChars();
        charsToMake--;
        if(charsToMake <= 0)
        {
            CancelInvoke("addChar");
        }
    }

    public void getCharsIn(float t)
    {
        Invoke("getChars", t);
    }

    public void getChars()
    {

        chars = GetComponentsInChildren<mainCharControl>();

        int i = 0;
        foreach (mainCharControl char_ in chars)
        {
            char_.GetComponent<SpriteRenderer>().sortingOrder = i;
            i++;
        }

        if(chars.Length > 0)
        {
            followTargetScript.target = chars[0].transform;
        }
    }

}
