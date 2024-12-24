using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui_score : MonoBehaviour {
    
    public Score _score;
    public int _n;

    public TextMeshProUGUI  tCode;
    public TextMeshProUGUI  tTitle;
    public TextMeshProUGUI  tComposer;
    public TextMeshProUGUI  tStart;
    public TextMeshProUGUI  tDay;
    public Button bChange;

    void Start() {
        
        StartCoroutine(ExecuteTasks());
    }

    IEnumerator ExecuteTasks() {
        yield return new WaitForSeconds(0.001f); // Wait for 1 second
        DisplayData();
    }
    
    private void DisplayData() {

        bChange.onClick.AddListener(ChangeData);
        tCode.color = Meta.clScoreStyle[_score.Style];
        
        tCode.text = _score.Code;
        tTitle.text = _score.Title;
        tComposer.text = _score.Composer;

        if (_score.StartTime.Year > 1) {
            tStart.text = _score.StartTime.ToString("dd.MM.yyyy");
        }

        if (_score.StartTime.Year > 1) {
            if (_score.EndTime.Year > 1) {
                tDay.text = (_score.EndTime - _score.StartTime).Days + "d";

            } else {
                tDay.text = (DateTime.Today - _score.StartTime).Days + "d";
            }
            
        }

        bChange.transform.GetChild(0).GetComponent<Image>().color = Meta.clScoreSts[_score.Sts];

    }

    private void ChangeData() {
        Controller.actualScore = _score;
        Controller.stsScoreChange = 1;
    }



    



        

}
