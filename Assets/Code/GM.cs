using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class GM {
    
    private List<Score> _scores;
    private List<Rec> _recs;
    
    public GM(List<Score> scores, List<Rec> recs) {
        _scores = scores;
        _recs = recs;
    }
    
    
    public static void Save() {

        GM game = new GM(Engine.ctrl.scores, Engine.ctrl.recs);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/TalentTracker.gd");
        bf.Serialize(file, game);
        file.Close();
        
    }
    
    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/TalentTracker.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/TalentTracker.gd", FileMode.Open);
            var game = (GM)bf.Deserialize(file);
            file.Close();
            Engine.ctrl.scores = game._scores;
            Engine.ctrl.recs = game._recs;
        }
    }
    
    
    public static void Delete() {
        Engine.ctrl.scores.Clear();
        Engine.ctrl.recs.Clear();
        Save();
    }
    
}
