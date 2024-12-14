using System;

[Serializable]
public class Score {
	
	private string _code;
	private int _n;
	private int _grade;
	private int _sts;
	private string _composer;
	private string _title;
	private int _style;
	private DateTime _startTime;
	private DateTime _endTime;

	public Score(int n, int grade, string composer, string title, int style) {
		_n = n;
		_grade = grade;
		_code = Logic.GetCodeByGrade(grade) + "" + n.ToString("000");
		_composer = composer;
		_title = title;
		_sts = 0;
		_style = style;
	}
	
	public Score(Score s) {
		_n = s.N;
		_grade = s.Grade;
		_code = Logic.GetCodeByGrade(s.Grade) + "" + s.N.ToString("000");
		_composer = s.Composer;
		_title = s.Title;
		_sts = 0;
		_style = s.Style;
	}

	public static Score CreateScore(Score _s) {
		Score s = new Score(_s);
		return s;
	}

	public string Code {
		get => _code;
		set => _code = value;
	}

	public int N {
		get => _n;
		set => _n = value;
	}

	public int Grade {
		get => _grade;
		set => _grade = value;
	}

	public int Sts {
		get => _sts;
		set => _sts = value;
	}

	public string Composer {
		get => _composer;
		set => _composer = value;
	}

	public string Title {
		get => _title;
		set => _title = value;
	}

	public int Style {
		get => _style;
		set => _style = value;
	}

	public DateTime StartTime {
		get => _startTime;
		set => _startTime = value;
	}

	public DateTime EndTime {
		get => _endTime;
		set => _endTime = value;
	}
}
