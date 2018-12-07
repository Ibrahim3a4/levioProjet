package entites;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;


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
	private Object reason;

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

	public Object getReason() {
		return this.reason;
	}

	public void setReason(Object reason) {
		this.reason = reason;
	}

}