package entites;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;


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

}