package Entities;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the Requests database table.
 * 
 */
@Entity
@Table(name="Requests")
@NamedQuery(name="Request.findAll", query="SELECT r FROM Request r")
public class Request implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int idRequest;

	private  String career;

	private String depositDate;

	private String endDate;

	private  String profileRequired;

	private  String requirements;

	private String startDate;

	public Request() {
	}

	public int getIdRequest() {
		return this.idRequest;
	}

	public void setIdRequest(int idRequest) {
		this.idRequest = idRequest;
	}

	public  String getCareer() {
		return this.career;
	}

	public void setCareer( String career) {
		this.career = career;
	}

	public String getDepositDate() {
		return this.depositDate;
	}

	public void setDepositDate(String depositDate) {
		this.depositDate = depositDate;
	}

	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public Object getProfileRequired() {
		return this.profileRequired;
	}

	public void setProfileRequired( String profileRequired) {
		this.profileRequired = profileRequired;
	}

	public  String getRequirements() {
		return this.requirements;
	}

	public void setRequirements( String requirements) {
		this.requirements = requirements;
	}

	public String getStartDate() {
		return this.startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

}