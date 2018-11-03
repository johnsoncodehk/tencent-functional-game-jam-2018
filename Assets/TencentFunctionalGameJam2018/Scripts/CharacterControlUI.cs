﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControlUI : MonoBehaviour
{

    /* Config Propertys */
    public Button combineButton, dropButton;
    public Character character;

    /* Unity Events */
    void Awake()
    {
        combineButton.onClick.AddListener(OnClickCombine);
        dropButton.onClick.AddListener(OnClickDrop);
    }
    void Update()
    {
        combineButton.interactable = !!character.touchingWordGiver;
        dropButton.interactable = character.wordHolder.current.name != character.startWord.name;
    }

    /* Button Events */
    void OnClickCombine()
    {
        character.CombineWords();
    }
    void OnClickDrop()
    {
        character.ResetWord();
    }
}
