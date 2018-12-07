package entites;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the IdentityUserLogins database table.
 * 
 */
@Entity
@Table(name="IdentityUserLogins")
@NamedQuery(name="IdentityUserLogin.findAll", query="SELECT i FROM IdentityUserLogin i")
public class IdentityUserLogin implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="UserId")
	private String userId;

	@Column(name="LoginProvider")
	private Object loginProvider;

	@Column(name="ProviderKey")
	private Object providerKey;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="User_Id")
	private User user;

	public IdentityUserLogin() {
	}

	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public Object getLoginProvider() {
		return this.loginProvider;
	}

	public void setLoginProvider(Object loginProvider) {
		this.loginProvider = loginProvider;
	}

	public Object getProviderKey() {
		return this.providerKey;
	}

	public void setProviderKey(Object providerKey) {
		this.providerKey = providerKey;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

}