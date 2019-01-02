package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;


/**
 * The persistent class for the InterMandates database table.
 * 
 */
@Entity
@Table(name="InterMandates")
@NamedQuery(name="InterMandate.findAll", query="SELECT i FROM InterMandate i")
public class InterMandate implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="InterMandateId")
	private int interMandateId;

	@Column(name="EndDate")
	private Timestamp endDate;

	@Column(name="StartDate")
	private Timestamp startDate;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="IdResource")
	private User user;

	//bi-directional many-to-one association to User
	@OneToMany(mappedBy="interMandate1")
	private List<User> users1;

	//bi-directional many-to-one association to User
	@OneToMany(mappedBy="interMandate2")
	private List<User> users2;

	public InterMandate() {
	}

	public int getInterMandateId() {
		return this.interMandateId;
	}

	public void setInterMandateId(int interMandateId) {
		this.interMandateId = interMandateId;
	}

	public Timestamp getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}

	public Timestamp getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public List<User> getUsers1() {
		return this.users1;
	}

	public void setUsers1(List<User> users1) {
		this.users1 = users1;
	}

	public User addUsers1(User users1) {
		getUsers1().add(users1);
		users1.setInterMandate1(this);

		return users1;
	}

	public User removeUsers1(User users1) {
		getUsers1().remove(users1);
		users1.setInterMandate1(null);

		return users1;
	}

	public List<User> getUsers2() {
		return this.users2;
	}

	public void setUsers2(List<User> users2) {
		this.users2 = users2;
	}

	public User addUsers2(User users2) {
		getUsers2().add(users2);
		users2.setInterMandate2(this);

		return users2;
	}

	public User removeUsers2(User users2) {
		getUsers2().remove(users2);
		users2.setInterMandate2(null);

		return users2;
	}

}