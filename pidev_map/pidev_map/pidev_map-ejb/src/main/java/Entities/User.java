package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;


/**
 * The persistent class for the Users database table.
 * 
 */
@Entity
@Table(name="Users")
@NamedQuery(name="Users.findAll", query="SELECT u FROM User u")
public class User implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(name="Id")
	private String id;

	@Column(name="AccessFailedCount")
	private int accessFailedCount;

	@Column(name="Addresse")
	private  String addresse;
//enum
	@Column(name="Availability",nullable = true)
	private String availability;

	@Column(name="BusinessProfile")
	private  String businessProfile;
//enum
	@Column(name="Category")
	private int category;
//enum
	@Column(name="Contract")
	private String contract;
//on doit le changer de type file
	@Column(name="CV")
	private String cv;

	@Column(name="Discriminator")
	private String discriminator;

	@Column(name="Email")
	private String email;

	@Column(name="EmailConfirmed")
	private boolean emailConfirmed;

	@Column(name="FirstName")
	private String firstName;

	@Column(name="Gender")
	private String gender;
// on doit le changer de type date
	@Column(name="HiringDate")
	private String hiringDate;

	@Column(name="LastName")
	private String lastName;

	@Column(name="LockoutEnabled")
	private boolean lockoutEnabled;

	@Column(name="LockoutEndDateUtc")
	private Timestamp lockoutEndDateUtc;

	@Column(name="Logo")
	private  String logo;

	@Column(name="NbProjAf")
	private int nbProjAf;

	@Column(name="NbResInServ")
	private int nbResInServ;

	public User(String id, String firstName) {
		super();
		this.id = id;
		this.firstName = firstName;
	}



	@Column(name="OrganizationalChart")
	private String organizationalChart;

	@Column(name="PasswordHash")
	private String passwordHash;

	@Column(name="PhoneNumber")
	private  String phoneNumber;

	@Column(name="PhoneNumberConfirmed")
	private boolean phoneNumberConfirmed;

	@Column(name="Photo")
	private  String photo;

	@Column(name="Rating")
	
	private int rating=0;

	@Column(name="Salary")
	private float salary;

	@Column(name="SecurityStamp")
	private  String securityStamp;

	@Column(name="Seniority")
	private  String seniority;

	@Column(name="TwoFactorEnabled")
	private boolean twoFactorEnabled;
//enum
	@Column(name="Type")
	private String type;

	@Column(name="UserName")
	private  String userName;

	//bi-directional many-to-one association to InterMandate
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	private List<InterMandate> interMandates;

	//bi-directional many-to-one association to Mandate
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	private List<Mandate> mandates;

	//bi-directional many-to-one association to Message
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	private List<Message> messages;

	//bi-directional many-to-one association to Project
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	private List<Project> projects;

	//bi-directional many-to-one association to SkillResource
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	private List<SkillResource> skillResources;

	//bi-directional many-to-one association to InterMandate
	@ManyToOne(cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	@JoinColumn(name="InterMandate_InterMandateId")
	private InterMandate interMandate1;

	//bi-directional many-to-one association to InterMandate
	@ManyToOne(cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	@JoinColumn(name="InterMandateId")
	private InterMandate interMandate2;

	//bi-directional many-to-many association to DayOff
	@ManyToMany(cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	@JoinTable(
		name="DayOffResources"
		, joinColumns={
			@JoinColumn(name="Resource_Id")
			}
		, inverseJoinColumns={
			@JoinColumn(name="DayOff_DayoffId")
			}
		)
	private List<DayOff> dayOffs;
	
	
	@OneToMany(mappedBy="user")
	private List<Test> Tests;
	
	
	@ManyToOne(cascade = CascadeType.ALL,fetch=FetchType.EAGER)
	@JoinColumn(name="ParrainId")
	private Parrain Parrain ;


	public Parrain getParrain() {
		return Parrain;
	}

	public void setParrain(Parrain parrain) {
		Parrain = parrain;
	}

	

	//bi-directional many-to-many association to Holiday
	@ManyToMany(cascade=CascadeType.PERSIST, fetch = FetchType.LAZY)
	@JoinTable(
		name="HolidayResources"
		, joinColumns={
			@JoinColumn(name="Resource_Id")
			}
		, inverseJoinColumns={
			@JoinColumn(name="Holiday_HolidayId")
			}
		)
	private List<Holiday> holidays;

	public User() {
	}

	

	public User(String id) {
		super();
		this.id = id;
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public int getAccessFailedCount() {
		return this.accessFailedCount;
	}

	public void setAccessFailedCount(int accessFailedCount) {
		this.accessFailedCount = accessFailedCount;
	}

	public  String getAddresse() {
		return this.addresse;
	}

	public void setAddresse( String addresse) {
		this.addresse = addresse;
	}

	public String getAvailability() {
		return this.availability;
	}

	public void setAvailability(String availability) {
		this.availability = availability;
	}

	public  String getBusinessProfile() {
		return this.businessProfile;
	}

	public void setBusinessProfile( String businessProfile) {
		this.businessProfile = businessProfile;
	}

	public int getCategory() {
		return this.category;
	}

	public void setCategory(int category) {
		this.category = category;
	}

	public String getContract() {
		return this.contract;
	}

	public void setContract(String contract) {
		this.contract = contract;
	}

	public String getCv() {
		return this.cv;
	}

	public void setCv(String cv) {
		this.cv = cv;
	}

	public String getDiscriminator() {
		return this.discriminator;
	}

	public void setDiscriminator(String discriminator) {
		this.discriminator = discriminator;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public boolean getEmailConfirmed() {
		return this.emailConfirmed;
	}

	public void setEmailConfirmed(boolean emailConfirmed) {
		this.emailConfirmed = emailConfirmed;
	}

	public String getFirstName() {
		return this.firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getGender() {
		return this.gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getHiringDate() {
		return this.hiringDate;
	}

	public void setHiringDate(String hiringDate) {
		this.hiringDate = hiringDate;
	}

	public String getLastName() {
		return this.lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public boolean getLockoutEnabled() {
		return this.lockoutEnabled;
	}

	public void setLockoutEnabled(boolean lockoutEnabled) {
		this.lockoutEnabled = lockoutEnabled;
	}

	public Timestamp getLockoutEndDateUtc() {
		return this.lockoutEndDateUtc;
	}

	public void setLockoutEndDateUtc(Timestamp lockoutEndDateUtc) {
		this.lockoutEndDateUtc = lockoutEndDateUtc;
	}

	public  String getLogo() {
		return this.logo;
	}

	public void setLogo( String logo) {
		this.logo = logo;
	}

	public int getNbProjAf() {
		return this.nbProjAf;
	}

	public void setNbProjAf(int nbProjAf) {
		this.nbProjAf = nbProjAf;
	}

	public int getNbResInServ() {
		return this.nbResInServ;
	}

	public void setNbResInServ(int nbResInServ) {
		this.nbResInServ = nbResInServ;
	}

	public String getOrganizationalChart() {
		return this.organizationalChart;
	}

	public void setOrganizationalChart(String organizationalChart) {
		this.organizationalChart = organizationalChart;
	}

	public String getPasswordHash() {
		return this.passwordHash;
	}

	public void setPasswordHash(String passwordHash) {
		this.passwordHash = passwordHash;
	}

	public  String getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber( String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public boolean getPhoneNumberConfirmed() {
		return this.phoneNumberConfirmed;
	}

	public void setPhoneNumberConfirmed(boolean phoneNumberConfirmed) {
		this.phoneNumberConfirmed = phoneNumberConfirmed;
	}

	public  String getPhoto() {
		return this.photo;
	}

	public void setPhoto( String photo) {
		this.photo = photo;
	}

	public int getRating() {
		return this.rating;
	}

	public void setRating(int rating) {
		this.rating = rating;
	}

	public float getSalary() {
		return this.salary;
	}

	public void setSalary(float salary) {
		this.salary = salary;
	}

	public  String getSecurityStamp() {
		return this.securityStamp;
	}

	public void setSecurityStamp( String securityStamp) {
		this.securityStamp = securityStamp;
	}

	public  String getSeniority() {
		return this.seniority;
	}

	public void setSeniority( String seniority) {
		this.seniority = seniority;
	}

	public boolean getTwoFactorEnabled() {
		return this.twoFactorEnabled;
	}

	public void setTwoFactorEnabled(boolean twoFactorEnabled) {
		this.twoFactorEnabled = twoFactorEnabled;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public  String getUserName() {
		return this.userName;
	}

	public void setUserName( String userName) {
		this.userName = userName;
	}

	public List<InterMandate> getInterMandates() {
		return this.interMandates;
	}

	public void setInterMandates(List<InterMandate> interMandates) {
		this.interMandates = interMandates;
	}

	public InterMandate addInterMandate(InterMandate interMandate) {
		getInterMandates().add(interMandate);
		interMandate.setUser(this);

		return interMandate;
	}

	public InterMandate removeInterMandate(InterMandate interMandate) {
		getInterMandates().remove(interMandate);
		interMandate.setUser(null);

		return interMandate;
	}

	public List<Mandate> getMandates() {
		return this.mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}

	public Mandate addMandate(Mandate mandate) {
		getMandates().add(mandate);
		mandate.setUser(this);

		return mandate;
	}

	public Mandate removeMandate(Mandate mandate) {
		getMandates().remove(mandate);
		mandate.setUser(null);

		return mandate;
	}

	public List<Message> getMessages() {
		return this.messages;
	}

	public void setMessages(List<Message> messages) {
		this.messages = messages;
	}

	public Message addMessage(Message message) {
		getMessages().add(message);
		message.setUser(this);

		return message;
	}

	public Message removeMessage(Message message) {
		getMessages().remove(message);
		message.setUser(null);

		return message;
	}

	public List<Project> getProjects() {
		return this.projects;
	}

	public void setProjects(List<Project> projects) {
		this.projects = projects;
	}

	public Project addProject(Project project) {
		getProjects().add(project);
		project.setUser(this);

		return project;
	}

	public Project removeProject(Project project) {
		getProjects().remove(project);
		project.setUser(null);

		return project;
	}

	public List<SkillResource> getSkillResources() {
		return this.skillResources;
	}

	public void setSkillResources(List<SkillResource> skillResources) {
		this.skillResources = skillResources;
	}

	public SkillResource addSkillResource(SkillResource skillResource) {
		getSkillResources().add(skillResource);
		skillResource.setUser(this);

		return skillResource;
	}

	public SkillResource removeSkillResource(SkillResource skillResource) {
		getSkillResources().remove(skillResource);
		skillResource.setUser(null);

		return skillResource;
	}

	public InterMandate getInterMandate1() {
		return this.interMandate1;
	}

	public void setInterMandate1(InterMandate interMandate1) {
		this.interMandate1 = interMandate1;
	}

	public InterMandate getInterMandate2() {
		return this.interMandate2;
	}

	public void setInterMandate2(InterMandate interMandate2) {
		this.interMandate2 = interMandate2;
	}

	public List<DayOff> getDayOffs() {
		return this.dayOffs;
	}

	public void setDayOffs(List<DayOff> dayOffs) {
		this.dayOffs = dayOffs;
	}

	public List<Holiday> getHolidays() {
		return this.holidays;
	}

	public void setHolidays(List<Holiday> holidays) {
		this.holidays = holidays;
	}

	@Override
	public String toString() {
		return "User [id=" + id + ", email=" + email + ", Parrain=" + Parrain + "]";
	}


	
}