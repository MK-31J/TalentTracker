
public class Grade {
	
	public Grade(int exp, int hour) {
		Exp = exp;
		Hour = hour;
		Week = hour/10;
	}

	public int Exp { get; set; }

	public int Hour { get; set; }

	public int Week { get; set; }
	
}
