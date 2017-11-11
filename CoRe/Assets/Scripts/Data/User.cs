using System.Collections;
using System.Collections.Generic;

public class User {
	private static User instance;

	public string username;
	public string email;
	public string password;

	protected User(){}

	public static User getInstance(){
		if (instance == null) {
			instance = new User ();
		} 

		return instance;
	}


}
