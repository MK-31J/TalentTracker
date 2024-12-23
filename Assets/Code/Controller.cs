using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour {
    
    public List<Score> scores;
    public List<Rec> recs;
    public List<Grade> grades;

    public static Score actualScore;
    public static int stsScoreChange;
    
    public static Rec actualRec;
    public static int stsRecChange;

    private void Awake() {
        scores = new List<Score>();
        recs = new List<Rec>();
        grades = new List<Grade>();
        InitGrades();
        

    }

    private void InitGrades() {
        grades.Add(new Grade(0, 50));
        grades.Add(new Grade(1, 80));
        grades.Add(new Grade(2, 110));
        grades.Add(new Grade(3, 140));
        grades.Add(new Grade(4, 180));
        grades.Add(new Grade(50, 240));
        grades.Add(new Grade(55, 300));
        grades.Add(new Grade(60, 300));
        grades.Add(new Grade(65, 300));
        grades.Add(new Grade(70, 300));
        grades.Add(new Grade(75, 300));
        grades.Add(new Grade(80, 300));
        grades.Add(new Grade(85, 300));
        grades.Add(new Grade(90, 300));
        grades.Add(new Grade(95, 300));
        grades.Add(new Grade(100, 300));
        grades.Add(new Grade(105, 300));
        grades.Add(new Grade(110, 300));
        grades.Add(new Grade(115, 300));
        grades.Add(new Grade(120, 300));
    }

    void Start() {
        GM.Load();

        // scores.Add(new Score(4, 1, "Krieger", "Minuet in A Minor", 0, 1));
        // scores.Add(new Score(5, 1, "Mozart", "MMMM", 0, 1));
        // scores.Add(new Score(6, 1, "Duncombe", "DDD", 0, 1));
        // GM.Save();


    }


}
