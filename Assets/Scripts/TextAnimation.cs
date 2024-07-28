using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    [Range(0, 1)]public float delay;
    private TMP_Text tMP_Text;

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

    private IEnumerator Typewriter(TMP_Text text, float delay)
    {
        // 需要先渲染text才能正确统计字数
        text.ForceMeshUpdate();
        TMP_TextInfo textInfo = text.textInfo;
        int textCount = textInfo.characterCount;
        for (int i = 0; i < textCount; i++)
        {
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delay);
        }
    }
}
