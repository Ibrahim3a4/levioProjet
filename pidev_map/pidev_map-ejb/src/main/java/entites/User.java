package entites;

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
@NamedQuery(name="User.findAll", query="SELECT u FROM User u")
public class User implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="Id")
	private String id;

	@Column(name="AccessFailedCount")
	private int accessFailedCount;

	@Column(name="Addresse")
	private Object addresse;

	@Column(name="Availability")
	private int availability;

	@Column(name="BusinessProfile")
	private Object businessProfile;

	@Column(name="Category")
	private int category;

	@Column(name="Contract")
	private int contract;

	@Column(name="CV")
	private Object cv;

	@Column(name="Discriminator")
	private Object discriminator;

	@Column(name="Email")
	private Object email;

	@Column(name="EmailConfirmed")
	private boolean emailConfirmed;

	@Column(name="FirstName")
	private Object firstName;

	@Column(name="Gender")
	private Object gender;

	@Column(name="HiringDate")
	private String hiringDate;

	@Column(name="LastName")
	private Object lastName;

	@Column(name="LockoutEnabled")
	private boolean lockoutEnabled;

	@Column(name="LockoutEndDateUtc")
	private Timestamp lockoutEndDateUtc;

	@Column(name="Logo")
	private Object logo;

	@Column(name="NbProjAf")
	private int nbProjAf;

	@Column(name="NbResInServ")
	private int nbResInServ;

	@Column(name="OrganizationalChart")
	private Object organizationalChart;

	@Column(name="PasswordHash")
	private Object passwordHash;

	@Column(name="PhoneNumber")
	private Object phoneNumber;

	@Column(name="PhoneNumberConfirmed")
	private boolean phoneNumberConfirmed;

	@Column(name="Photo")
	private Object photo;

	@Column(name="Rating")
	private int rating;

	@Column(name="Salary")
	private float salary;

	@Column(name="SecurityStamp")
	private Object securityStamp;

	@Column(name="Seniority")
	private Object seniority;

	@Column(name="TwoFactorEnabled")
	private boolean twoFactorEnabled;

	@Column(name="Type")
	private int type;

	@Column(name="UserName")
	private Object userName;

	//bi-directional many-to-one association to IdentityUserLogin
	@OneToMany(mappedBy="user")
	private List<IdentityUserLogin> identityUserLogins;

	//bi-directional many-to-one association to InterMandate
	@OneToMany(mappedBy="user")
	private List<InterMandate> interMandates;

	//bi-directional many-to-one association to Message
	@OneToMany(mappedBy="user")
	private List<Message> messages;

	//bi-directional many-to-one association to Project
	@OneToMany(mappedBy="user")
	private List<Project> projects;

	//bi-directional many-to-one association to InterMandate
	@ManyToOne
	@JoinColumn(name="InterMandateId")
	private InterMandate interMandate1;

	//bi-directional many-to-one association to InterMandate
	@ManyToOne
	@JoinColumn(name="InterMandate_InterMandateId")
	private InterMandate interMandate2;

	public User() {
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

	public Object getAddresse() {
		return this.addresse;
	}

	public void setAddresse(Object addresse) {
		this.addresse = addresse;
	}

	public int getAvailability() {
		return this.availability;
	}

	public void setAvailability(int availability) {
		this.availability = availability;
	}

	public Object getBusinessProfile() {
		return this.businessProfile;
	}

	public void setBusinessProfile(Object businessProfile) {
		this.businessProfile = businessProfile;
	}

	public int getCategory() {
		return this.category;
	}

	public void setCategory(int category) {
		this.category = category;
	}

	public int getContract() {
		return this.contract;
	}

	public void setContract(int contract) {
		this.contract = contract;
	}

	public Object getCv() {
		return this.cv;
	}

	public void setCv(Object cv) {
		this.cv = cv;
	}

	public Object getDiscriminator() {
		return this.discriminator;
	}

	public void setDiscriminator(Object discriminator) {
		this.discriminator = discriminator;
	}

	public Object getEmail() {
		return this.email;
	}

	public void setEmail(Object email) {
		this.email = email;
	}

	public boolean getEmailConfirmed() {
		return this.emailConfirmed;
	}

	public void setEmailConfirmed(boolean emailConfirmed) {
		this.emailConfirmed = emailConfirmed;
	}

	public Object getFirstName() {
		return this.firstName;
	}

	public void setFirstName(Object firstName) {
		this.firstName = firstName;
	}

	public Object getGender() {
		return this.gender;
	}

	public void setGender(Object gender) {
		this.gender = gender;
	}

	public String getHiringDate() {
		return this.hiringDate;
	}

	public void setHiringDate(String hiringDate) {
		this.hiringDate = hiringDate;
	}

	public Object getLastName() {
		return this.lastName;
	}

	public void setLastName(Object lastName) {
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

	public Object getLogo() {
		return this.logo;
	}

	public void setLogo(Object logo) {
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

	public Object getOrganizationalChart() {
		return this.organizationalChart;
	}

	public void setOrganizationalChart(Object organizationalChart) {
		this.organizationalChart = organizationalChart;
	}

	public Object getPasswordHash() {
		return this.passwordHash;
	}

	public void setPasswordHash(Object passwordHash) {
		this.passwordHash = passwordHash;
	}

	public Object getPhoneNumber() {
		return this.phoneNumber;
	}

	public void setPhoneNumber(Object phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public boolean getPhoneNumberConfirmed() {
		return this.phoneNumberConfirmed;
	}

	public void setPhoneNumberConfirmed(boolean phoneNumberConfirmed) {
		this.phoneNumberConfirmed = phoneNumberConfirmed;
	}

	public Object getPhoto() {
		return this.photo;
	}

	public void setPhoto(Object photo) {
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

	public Object getSecurityStamp() {
		return this.securityStamp;
	}

	public void setSecurityStamp(Object securityStamp) {
		this.securityStamp = securityStamp;
	}

	public Object getSeniority() {
		return this.seniority;
	}

	public void setSeniority(Object seniority) {
		this.seniority = seniority;
	}

	public boolean getTwoFactorEnabled() {
		return this.twoFactorEnabled;
	}

	public void setTwoFactorEnabled(boolean twoFactorEnabled) {
		this.twoFactorEnabled = twoFactorEnabled;
	}

	public int getType() {
		return this.type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public Object getUserName() {
		return this.userName;
	}

	public void setUserName(Object userName) {
		this.userName = userName;
	}

	public List<IdentityUserLogin> getIdentityUserLogins() {
		return this.identityUserLogins;
	}

	public void setIdentityUserLogins(List<IdentityUserLogin> identityUserLogins) {
		this.identityUserLogins = identityUserLogins;
	}

	public IdentityUserLogin addIdentityUserLogin(IdentityUserLogin identityUserLogin) {
		getIdentityUserLogins().add(identityUserLogin);
		identityUserLogin.setUser(this);

		return identityUserLogin;
	}

	public IdentityUserLogin removeIdentityUserLogin(IdentityUserLogin identityUserLogin) {
		getIdentityUserLogins().remove(identityUserLogin);
		identityUserLogin.setUser(null);

		return identityUserLogin;
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

}