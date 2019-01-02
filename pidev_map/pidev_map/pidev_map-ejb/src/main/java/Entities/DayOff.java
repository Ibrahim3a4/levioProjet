package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;


/**
 * The persistent class for the DayOffs database table.
 * 
 */
@Entity
@Table(name="DayOffs")
@NamedQuery(name="DayOff.findAll", query="SELECT d FROM DayOff d")
public class DayOff implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="DayoffId")
	private int dayoffId;

	private Timestamp DDate;

	@Column(name="Reason")
	private  String reason;

	//bi-directional many-to-many association to User
	@ManyToMany(mappedBy="dayOffs",cascade=CascadeType.PERSIST)
	private List<User> users;

	public DayOff() {
	}

	public int getDayoffId() {
		return this.dayoffId;
	}

	public void setDayoffId(int dayoffId) {
		this.dayoffId = dayoffId;
	}

	public Timestamp getDDate() {
		return this.DDate;
	}

	public void setDDate(Timestamp DDate) {
		this.DDate = DDate;
	}

	public  String getReason() {
		return this.reason;
	}

	public void setReason( String reason) {
		this.reason = reason;
	}

	public List<User> getUsers() {
		return this.users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

}