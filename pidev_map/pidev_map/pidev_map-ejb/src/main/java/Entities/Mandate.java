package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;


/**
 * The persistent class for the Mandates database table.
 * 
 */
@Entity
@Table(name="Mandates")
@NamedQuery(name="Mandate.findAll", query="SELECT m FROM Mandate m")
public class Mandate implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private MandatePK id;

	@Column(name="Disponibility")
	private  String disponibility;

	@Column(name="EndDate")
	private Timestamp  endDate;

	@Column(name="Fees")
	private int fees;

	@Column(name="MandateId")
	private int mandateId;

	@Column(name="StartDate")
	private Timestamp  startDate;

	//bi-directional many-to-one association to MandateHistory
	@ManyToOne
	@JoinColumn(name="IdMandateHistory")
	private MandateHistory mandateHistory;

	//bi-directional many-to-one association to Project
	@ManyToOne
	@JoinColumn(name="IdProject",insertable=false,updatable=false)
	private Project project;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="IdResource",insertable=false,updatable=false)
	private User user;

	public Mandate() {
	}

	public MandatePK getId() {
		return this.id;
	}

	public void setId(MandatePK id) {
		this.id = id;
	}

	public Object getDisponibility() {
		return this.disponibility;
	}

	public void setDisponibility( String disponibility) {
		this.disponibility = disponibility;
	}

	public Timestamp  getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Timestamp  endDate) {
		this.endDate = endDate;
	}

	public int getFees() {
		return this.fees;
	}

	public void setFees(int fees) {
		this.fees = fees;
	}

	public int getMandateId() {
		return this.mandateId;
	}

	public void setMandateId(int mandateId) {
		this.mandateId = mandateId;
	}

	public Timestamp  getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Timestamp  startDate) {
		this.startDate = startDate;
	}

	public MandateHistory getMandateHistory() {
		return this.mandateHistory;
	}

	public void setMandateHistory(MandateHistory mandateHistory) {
		this.mandateHistory = mandateHistory;
	}

	public Project getProject() {
		return this.project;
	}

	public void setProject(Project project) {
		this.project = project;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public Mandate(MandatePK id, Timestamp  endDate, int fees, int mandateId,Timestamp startDate, Project project, User user) {
		super();
		this.id=id;
		this.endDate = endDate;
		this.fees = fees;
	
		this.mandateId = mandateId;
		this.startDate = startDate;
		this.project = project;
		this.user = user;
	}


	

}