using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] Dialogue _currentDialogue;

    int _currentSlideIndex = 0;

    [SerializeField] RuntimeData _runtimeData;

    void Awake(){
        GameEvents.DialogFinished += OnDialogFinished;
        GameEvents.DialogInitiated += OnDialogInitiated;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_runtimeData.CurrentGameplayState = GameplayState.InDialog;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (_currentSlideIndex < _currentDialogue.DialogSlides.Length - 1){
                _currentSlideIndex++;
                ShowSlide();
            }
            else{
                GameEvents.InvokeDialofFinished();
            }
                

        }
    }

    void OnDialogInitiated(object sender, EventArgs){
        _currentSlideIndex = 0;
        ShowSlide();
        LoadAvatar();
        GetComponent<Canvas>().enabled = true;
    }

    void OnDialogFinished(object sender, EventArgs){
        GetComponent<Canvas>().enabled = false;
        _runtimeData.CurrentGameplayState = GameplayState.FreeWalk;
    }

    void ShowSlide(){
        GameObject textObj = transform.Find("DialogText").gameObject;
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];
    }

    void LoadAvatar(){
        GameObject avatarObj = transform.Find("Avatar").gameObject;
        avatarObj.GetComponent<RawImage>().texture = _currentDialogue.NPCAvatar;

    }
}
