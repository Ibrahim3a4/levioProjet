package Entities;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
@Entity
public class Test {
	@Id
	private int testId;
	private String question1;
	private String question2;
	private String question3;
	private String question4;
	private String question5;
	private String question6;
	private String question7;
	private String question8;
	private String question9;
	private String question10;
	private String reponse1;
	private String reponse2;
	private String reponse3;
	private String reponse4;
	private String reponse5;
	private String reponse6;
	private String reponse7;
	private String reponse8;
	private String reponse9;
	private String reponse10;
	private String reponse1c;
	private String reponse2c;
	private String reponse3c;
	private String reponse4c;
	private String reponse5c;
	private String reponse6c;
	private String reponse7c;
	private String reponse8c;
	private String reponse9c;
	private String reponse10c;
	private boolean resultatTest;
	
	
      @ManyToOne
	 private User user;
	
	

}
