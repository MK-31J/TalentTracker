using System;

public class Score {
	
	private string _code;
	private int _n;
	private int _grade;
	private string _composer;
	private string _title;
	private int _size;
	private DateTime _startTime;
	private DateTime _endTime;

	public Score(int n, int grade, string composer, string title, int size) {
		_n = n;
		_grade = grade;
		_code = Logic.GetCodeByGrade(grade) + "" + n.ToString("###");
		_composer = composer;
		_title = title;
		_size = size;
	}
	
}
