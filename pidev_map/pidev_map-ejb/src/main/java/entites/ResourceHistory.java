package entites;

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
	private Object firstName;

	@Column(name="LastName")
	private Object lastName;

	@Column(name="Username")
	private Object username;

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

	public void setFirstName(Object firstName) {
		this.firstName = firstName;
	}

	public Object getLastName() {
		return this.lastName;
	}

	public void setLastName(Object lastName) {
		this.lastName = lastName;
	}

	public Object getUsername() {
		return this.username;
	}

	public void setUsername(Object username) {
		this.username = username;
	}

}