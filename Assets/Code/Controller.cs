using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    
    public List<Score> scores;
    public List<Rec> recs;


    private void Awake() {
        scores = new List<Score>();
        recs = new List<Rec>();
        

    }

    void Start() {
        GM.Load();


        // scores.Add(new Score(4, 1, "Krieger", "Minuet in A Minor", 0, 1));
        // scores.Add(new Score(5, 1, "Mozart", "MMMM", 0, 1));
        // scores.Add(new Score(6, 1, "Duncombe", "DDD", 0, 1));
        // GM.Save();


    }

    // Update is called once per frame
    void Update() {
        
    }
}
