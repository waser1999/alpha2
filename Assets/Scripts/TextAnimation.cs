using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    [Range(0, 1)]public float delay;
    [Range(0, 1)]public float delayCursor = 0.5f;
    public string text;
    public string cursor = "|";
    private TMP_Text tMP_Text;
    private bool cursorVisible = true;

    void Start()
    {
        tMP_Text = gameObject.GetComponent<TMP_Text>();
    }

    public void Typewriter()
    {
        StartCoroutine(Typewriter(tMP_Text, delay));
    }

    public void Exit()
    {
        tMP_Text.maxVisibleCharacters = 0;
    }

    private IEnumerator Typewriter(TMP_Text tMP_Text, float delay)
    {
        foreach (char c in text)
        {
            if(tMP_Text.text.Length > 0 && cursor.Length > 0){
                tMP_Text.text = tMP_Text.text.Remove(tMP_Text.text.Length - cursor.Length);
            }
            tMP_Text.text += c + cursor;
            yield return new WaitForSeconds(delay);
        }

        if(cursor.Length > 0){
            StartCoroutine(CursorUpdate());
        }
    }

    private IEnumerator CursorUpdate(){
        while(true){
            if(cursorVisible){
                tMP_Text.text = tMP_Text.text.Remove(tMP_Text.text.Length - cursor.Length);
            }
            else{
                tMP_Text.text += cursor;
            }
            cursorVisible = !cursorVisible;
            yield return new WaitForSeconds(delayCursor);
        }
    }
}
