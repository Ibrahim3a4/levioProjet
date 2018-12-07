package entites;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the Projects database table.
 * 
 */
@Entity
@Table(name="Projects")
@NamedQuery(name="Project.findAll", query="SELECT p FROM Project p")
public class Project implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="Project_id")
	private int project_id;

	@Column(name="Address")
	private Object address;

	@Column(name="EndDate")
	private String endDate;

	@Column(name="Image")
	private Object image;

	@Column(name="Name")
	private Object name;

	@Column(name="StartDate")
	private String startDate;

	@Column(name="TotalNbrLevio")
	private int totalNbrLevio;

	@Column(name="TotalNbrRessources")
	private int totalNbrRessources;

	@Column(name="Type")
	private int type;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="Client_Id")
	private User user;

	public Project() {
	}

	public int getProject_id() {
		return this.project_id;
	}

	public void setProject_id(int project_id) {
		this.project_id = project_id;
	}

	public Object getAddress() {
		return this.address;
	}

	public void setAddress(Object address) {
		this.address = address;
	}

	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	public Object getImage() {
		return this.image;
	}

	public void setImage(Object image) {
		this.image = image;
	}

	public Object getName() {
		return this.name;
	}

	public void setName(Object name) {
		this.name = name;
	}

	public String getStartDate() {
		return this.startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public int getTotalNbrLevio() {
		return this.totalNbrLevio;
	}

	public void setTotalNbrLevio(int totalNbrLevio) {
		this.totalNbrLevio = totalNbrLevio;
	}

	public int getTotalNbrRessources() {
		return this.totalNbrRessources;
	}

	public void setTotalNbrRessources(int totalNbrRessources) {
		this.totalNbrRessources = totalNbrRessources;
	}

	public int getType() {
		return this.type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

}