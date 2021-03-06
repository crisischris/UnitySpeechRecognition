﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour {
    [SerializeField]
    private string[] m_Keywords;
    private KeywordRecognizer m_Recognizer;
    public Material nightBox;
    public Material dayBox; 
    public GameObject sun;
    // Use this for initialization
    void Start () {
        m_Keywords = new string[3];
        m_Keywords[0] = "Day";
        m_Keywords[1] = "Night";
        m_Keywords[2] = "Home";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if(args.text == m_Keywords[0])
        {
            RenderSettings.skybox = dayBox;
            sun.SetActive(true);
        }
        if (args.text == m_Keywords[1])
        {
            RenderSettings.skybox = nightBox;
            sun.SetActive(false);
        }
    }
}
