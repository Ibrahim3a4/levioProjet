package Entities;

import java.io.Serializable;
import javax.persistence.*;



import java.util.List;


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

	public Project(int project_id, String address, String endDate, String image, String name, String startDate,
			int totalNbrLevio, int totalNbrRessources, int type, List<Mandate> mandates, User user) {
		super();
		this.project_id = project_id;
		this.address = address;
		this.endDate = endDate;
		this.image = image;
		this.name = name;
		this.startDate = startDate;
		this.totalNbrLevio = totalNbrLevio;
		this.totalNbrRessources = totalNbrRessources;
		this.type = type;
		this.mandates = mandates;
		this.user = user;
	}

	@Column(name="Address")
	private String address;

	@Column(name="EndDate")
	private String endDate;

	@Column(name="Image")
	private String image;
	
	@Column(name="Name")
	private  String name;

	@Column(name="StartDate")
	private String startDate;

	@Column(name="TotalNbrLevio")
	private int totalNbrLevio;

	@Column(name="TotalNbrRessources")
	private int totalNbrRessources;

	@Column(name="Type")
	private int type;

	//bi-directional many-to-one association to Mandate
	@OneToMany(mappedBy="project" )
	private List<Mandate> mandates;

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

	public  String getAddress() {
		return this.address;
	}

	public void setAddress( String address) {
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

	public void setImage( String image) {
		this.image = image;
	}

	public  String getName() {
		return this.name;
	}

	public void setName( String name) {
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

	public List<Mandate> getMandates() {
		return this.mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}

	public Mandate addMandate(Mandate mandate) {
		getMandates().add(mandate);
		mandate.setProject(this);

		return mandate;
	}

	public Mandate removeMandate(Mandate mandate) {
		getMandates().remove(mandate);
		mandate.setProject(null);

		return mandate;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public Project(int project_id) {
		super();
		
	}

	@Override
	public String toString() {
		return "Project [project_id=" + project_id + ", address=" + address + ", endDate=" + endDate + ", image="
				+ image + ", name=" + name + ", startDate=" + startDate + ", totalNbrLevio=" + totalNbrLevio
				+ ", totalNbrRessources=" + totalNbrRessources + ", type=" + type + ", mandates=" + mandates + ", user="
				+ user + "]";
	}
	

}