
using System;
using System.Collections.Generic;

[Serializable]
public class Rec {
	
	private DateTime _day;
	private List<Exercise> _exercises;

	public Rec(DateTime day) {
		_day = day;
		_exercises = new List<Exercise>();
	}

	public Rec(Rec r) {
		_day = r.Day;
		_exercises = r.Exercises;
	}
	
	public static Rec CreateRec(Rec _r) {
		var r = new Rec(_r);
		return r;
	}

	public DateTime Day {
		get => _day;
		set => _day = value;
	}

	public List<Exercise> Exercises {
		get => _exercises;
		set => _exercises = value;
	}
}





[Serializable]
public struct Exercise {
	
	public string _code;
	public int _quarter;

	public Exercise(string code, int quarter) {
		_code = code;
		_quarter = quarter;
	}
}
