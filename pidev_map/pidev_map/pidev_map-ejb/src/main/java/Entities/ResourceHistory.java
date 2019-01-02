package Entities;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the ResourceHistories database table.
 * 
 */
@Entity
@Table(name="ResourceHistories")
@NamedQuery(name="ResourceHistory.findAll", query="SELECT r FROM ResourceHistory r")
public class ResourceHistory implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ResourceHistoryId")
	private int resourceHistoryId;

	@Column(name="FirstName")
	private  String firstName;

	@Column(name="LastName")
	private  String lastName;

	@Column(name="Username")
	private  String username;

	public ResourceHistory() {
	}

	public int getResourceHistoryId() {
		return this.resourceHistoryId;
	}

	public void setResourceHistoryId(int resourceHistoryId) {
		this.resourceHistoryId = resourceHistoryId;
	}

	public Object getFirstName() {
		return this.firstName;
	}

	public void setFirstName( String firstName) {
		this.firstName = firstName;
	}

	public  String getLastName() {
		return this.lastName;
	}

	public void setLastName( String lastName) {
		this.lastName = lastName;
	}

	public Object getUsername() {
		return this.username;
	}

	public void setUsername( String username) {
		this.username = username;
	}

}