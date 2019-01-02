package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Date;
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
	private CategoryC category;
//enum
	@Column(name="Contract")
	private ContratT contract;
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
	private Date hiringDate;

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
	
	private int rating = 0;

	@ManyToOne
	@JoinColumn(name="IdProject")
	private Project project;
	
	
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
	private TypeC type;

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
	@OneToMany(mappedBy="user",cascade=CascadeType.PERSIST, fetch = FetchType.EAGER)
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

	

	public String getId() {
		return id;
	}



	public void setId(String id) {
		this.id = id;
	}



	public int getAccessFailedCount() {
		return accessFailedCount;
	}



	public void setAccessFailedCount(int accessFailedCount) {
		this.accessFailedCount = accessFailedCount;
	}



	public String getAddresse() {
		return addresse;
	}



	public void setAddresse(String addresse) {
		this.addresse = addresse;
	}



	public String getAvailability() {
		return availability;
	}



	public void setAvailability(String availability) {
		this.availability = availability;
	}



	public String getBusinessProfile() {
		return businessProfile;
	}



	public void setBusinessProfile(String businessProfile) {
		this.businessProfile = businessProfile;
	}



	public CategoryC getCategory() {
		return category;
	}



	public void setCategory(CategoryC category) {
		this.category = category;
	}



	public ContratT getContract() {
		return contract;
	}



	public void setContract(ContratT contract) {
		this.contract = contract;
	}



	public String getCv() {
		return cv;
	}



	public void setCv(String cv) {
		this.cv = cv;
	}



	public String getDiscriminator() {
		return discriminator;
	}



	public void setDiscriminator(String discriminator) {
		this.discriminator = discriminator;
	}



	public String getEmail() {
		return email;
	}



	public void setEmail(String email) {
		this.email = email;
	}



	public boolean isEmailConfirmed() {
		return emailConfirmed;
	}



	public void setEmailConfirmed(boolean emailConfirmed) {
		this.emailConfirmed = emailConfirmed;
	}



	public String getFirstName() {
		return firstName;
	}



	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}



	public String getGender() {
		return gender;
	}



	public void setGender(String gender) {
		this.gender = gender;
	}



	public Date getHiringDate() {
		return hiringDate;
	}



	public void setHiringDate(Date hiringDate) {
		this.hiringDate = hiringDate;
	}



	public String getLastName() {
		return lastName;
	}



	public Project getProject() {
		return project;
	}



	public void setProject(Project project) {
		this.project = project;
	}



	public void setLastName(String lastName) {
		this.lastName = lastName;
	}



	public boolean isLockoutEnabled() {
		return lockoutEnabled;
	}



	public void setLockoutEnabled(boolean lockoutEnabled) {
		this.lockoutEnabled = lockoutEnabled;
	}



	public Timestamp getLockoutEndDateUtc() {
		return lockoutEndDateUtc;
	}



	public void setLockoutEndDateUtc(Timestamp lockoutEndDateUtc) {
		this.lockoutEndDateUtc = lockoutEndDateUtc;
	}



	public String getLogo() {
		return logo;
	}



	public void setLogo(String logo) {
		this.logo = logo;
	}



	public int getNbProjAf() {
		return nbProjAf;
	}



	public void setNbProjAf(int nbProjAf) {
		this.nbProjAf = nbProjAf;
	}



	public int getNbResInServ() {
		return nbResInServ;
	}



	public void setNbResInServ(int nbResInServ) {
		this.nbResInServ = nbResInServ;
	}



	public String getOrganizationalChart() {
		return organizationalChart;
	}



	public void setOrganizationalChart(String organizationalChart) {
		this.organizationalChart = organizationalChart;
	}



	public String getPasswordHash() {
		return passwordHash;
	}



	public void setPasswordHash(String passwordHash) {
		this.passwordHash = passwordHash;
	}



	public String getPhoneNumber() {
		return phoneNumber;
	}



	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}



	public boolean isPhoneNumberConfirmed() {
		return phoneNumberConfirmed;
	}



	public void setPhoneNumberConfirmed(boolean phoneNumberConfirmed) {
		this.phoneNumberConfirmed = phoneNumberConfirmed;
	}



	public String getPhoto() {
		return photo;
	}



	public void setPhoto(String photo) {
		this.photo = photo;
	}



	public int getRating() {
		return rating;
	}



	public void setRating(int rating) {
		this.rating = rating;
	}



	public float getSalary() {
		return salary;
	}



	public void setSalary(float salary) {
		this.salary = salary;
	}



	public String getSecurityStamp() {
		return securityStamp;
	}



	public void setSecurityStamp(String securityStamp) {
		this.securityStamp = securityStamp;
	}



	public String getSeniority() {
		return seniority;
	}



	public void setSeniority(String seniority) {
		this.seniority = seniority;
	}



	public boolean isTwoFactorEnabled() {
		return twoFactorEnabled;
	}



	public void setTwoFactorEnabled(boolean twoFactorEnabled) {
		this.twoFactorEnabled = twoFactorEnabled;
	}



	public TypeC getType() {
		return type;
	}



	public void setType(TypeC type) {
		this.type = type;
	}



	public String getUserName() {
		return userName;
	}



	public void setUserName(String userName) {
		this.userName = userName;
	}



	public List<InterMandate> getInterMandates() {
		return interMandates;
	}



	public void setInterMandates(List<InterMandate> interMandates) {
		this.interMandates = interMandates;
	}



	public List<Mandate> getMandates() {
		return mandates;
	}



	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}



	public List<Message> getMessages() {
		return messages;
	}



	public void setMessages(List<Message> messages) {
		this.messages = messages;
	}



	public List<Project> getProjects() {
		return projects;
	}



	public void setProjects(List<Project> projects) {
		this.projects = projects;
	}



	public List<SkillResource> getSkillResources() {
		return skillResources;
	}



	public void setSkillResources(List<SkillResource> skillResources) {
		this.skillResources = skillResources;
	}



	public InterMandate getInterMandate1() {
		return interMandate1;
	}



	public void setInterMandate1(InterMandate interMandate1) {
		this.interMandate1 = interMandate1;
	}



	public InterMandate getInterMandate2() {
		return interMandate2;
	}



	public void setInterMandate2(InterMandate interMandate2) {
		this.interMandate2 = interMandate2;
	}



	public List<DayOff> getDayOffs() {
		return dayOffs;
	}



	public void setDayOffs(List<DayOff> dayOffs) {
		this.dayOffs = dayOffs;
	}



	public List<Holiday> getHolidays() {
		return holidays;
	}



	public void setHolidays(List<Holiday> holidays) {
		this.holidays = holidays;
	}



	@Override
	public String toString() {
		return "User [userName=" + userName + "]";
	}



	
	
}