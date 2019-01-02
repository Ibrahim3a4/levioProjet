package Entities;

import java.io.Serializable;
import javax.persistence.*;

import java.util.Date;
import java.util.List;


/**
 * The persistent class for the Projects database table.
 * 
 */
@Entity
@Table(name="Projects")
@NamedQuery(name="Project.findAll", query="SELECT p FROM Project p")
public class Project implements Serializable , Comparable<Project> {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="Project_id")
	private int Project_id;


	@Column(name="Value")
	private long Value;
	public long getValue() {
		return Value;
	}

	public void setValue(long value) {
		Value = value;
	}

	@Column(name="Address")
	private String Address;

	@Column(name="EndDate")
	private Date EndDate;

	@Column(name="Image")
	private String Image;
	
	@Column(name="Name")
	private  String Name;

	@Column(name="StartDate")
	private Date StartDate;

	@Column(name="TotalNbrLevio")
	private int TotalNbrLevio;

	@Column(name="TotalNbrRessources")
	private int TotalNbrRessources;

	@Column(name="Type")
	private TypeP Type;

	//bi-directional many-to-one association to Mandate
	@OneToMany(mappedBy="project" )
	private List<Mandate> Mandates;
  
	@OneToMany(mappedBy="project",cascade=CascadeType.PERSIST, fetch = FetchType.EAGER)
	private List<User> users;
	//bi-directional many-to-one association to User
	
	@ManyToOne
	@JoinColumn(name="Client_Id")
	private User user;

	public int getProject_id() {
		return Project_id;
	}

	public void setProject_id(int project_id) {
		Project_id = project_id;
	}

	public String getAddress() {
		return Address;
	}

	public void setAddress(String address) {
		Address = address;
	}

	public Date getEndDate() {
		return EndDate;
	}

	public void setEndDate(Date endDate) {
		EndDate = endDate;
	}

	public String getImage() {
		return Image;
	}

	public void setImage(String image) {
		Image = image;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}



	public Date getStartDate() {
		return StartDate;
	}

	public void setStartDate(Date startDate) {
		StartDate = startDate;
	}

	

	

	public List<User> getUsers() {
		return users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

	public int getTotalNbrLevio() {
		return TotalNbrLevio;
	}

	public void setTotalNbrLevio(int totalNbrLevio) {
		TotalNbrLevio = totalNbrLevio;
	}

	public int getTotalNbrRessources() {
		return TotalNbrRessources;
	}

	public void setTotalNbrRessources(int totalNbrRessources) {
		TotalNbrRessources = totalNbrRessources;
	}

	public TypeP getType() {
		return Type;
	}

	public void setType(TypeP type) {
		Type = type;
	}

	public List<Mandate> getMandates() {
		return Mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		Mandates = mandates;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	@Override
	public int compareTo(Project o) {
		return getStartDate().compareTo(o.getStartDate());
	}

	@Override
	public String toString() {
		return "Project [Project_id=" + Project_id + ", Value=" + Value + ", Address=" + Address + ", EndDate="
				+ EndDate + ", Image=" + Image + ", Name=" + Name + ", StartDate=" + StartDate + ", TotalNbrLevio="
				+ TotalNbrLevio + ", TotalNbrRessources=" + TotalNbrRessources + ", Type=" + Type + ", Mandates="
				+ Mandates + ", users=" + users + ", user=" + user + "]";
	}


}