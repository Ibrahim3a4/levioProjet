package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;


/**
 * The persistent class for the MandateHistories database table.
 * 
 */
@Entity
@Table(name="MandateHistories")
@NamedQuery(name="MandateHistory.findAll", query="SELECT m FROM MandateHistory m")
public class MandateHistory implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="IdMandateHistory")
	private int idMandateHistory;

	@Column(name="SaveDate")
	private Timestamp saveDate;

	//bi-directional many-to-one association to Mandate
	@OneToMany(mappedBy="mandateHistory")
	private List<Mandate> mandates;

	public MandateHistory() {
	}

	public int getIdMandateHistory() {
		return this.idMandateHistory;
	}

	public void setIdMandateHistory(int idMandateHistory) {
		this.idMandateHistory = idMandateHistory;
	}

	public Timestamp getSaveDate() {
		return this.saveDate;
	}

	public void setSaveDate(Timestamp saveDate) {
		this.saveDate = saveDate;
	}

	public List<Mandate> getMandates() {
		return this.mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}

	public Mandate addMandate(Mandate mandate) {
		getMandates().add(mandate);
		mandate.setMandateHistory(this);

		return mandate;
	}

	public Mandate removeMandate(Mandate mandate) {
		getMandates().remove(mandate);
		mandate.setMandateHistory(null);

		return mandate;
	}

}