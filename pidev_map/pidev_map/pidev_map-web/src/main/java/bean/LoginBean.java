package bean;
import java.io.IOException;
import java.security.Provider.Service;
import java.util.Calendar;
import java.util.Date;

import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import Entities.User;
import Interfaces.UserServiceLocal;


@ManagedBean
@SessionScoped
public class LoginBean {
	// Models
	private User user = new User();
	private Date loginTime;
	private Boolean identifidUser;
	// Injection Of Dependency
	@EJB
	private UserServiceLocal userServicesLocal;
	private boolean loggedInAsAdmin=false;
	private boolean loggedInAsUser=false;
	
	public void checkAdmin() throws IOException{
		if (loggedInAsAdmin==false)
			{
				FacesContext.getCurrentInstance().getExternalContext().redirect("../login.jsf");
			}
	}
	public void checkUser() throws IOException{
		if (loggedInAsUser==false)
			{
				FacesContext.getCurrentInstance().getExternalContext().redirect("../login.jsf");
			}
	}
	public String logout() {
	
		FacesContext.getCurrentInstance().getExternalContext().invalidateSession();
		return "/login?faces-redirect=true";
	}
	
	// Recall services
	public String doLogin() {
		String navaigateTo = "";
		User userLoggedIn = userServicesLocal.findUserByLogin(user.getEmail(), user.getPasswordHash());
		if (userLoggedIn != null) {
			user = userLoggedIn;
			identifidUser = true;
			if (userLoggedIn.getEmail().equals("Admin@Admin.com")) {
				loggedInAsAdmin = true;
				navaigateTo = "/Admin/TimeLineProject?faces-redirect=true";
			} else {
				loggedInAsAdmin = true;
			
				navaigateTo = "/Admin/statTown?faces-redirect=true";
			}
		} else {
			FacesContext ctx = FacesContext.getCurrentInstance();
			ctx.addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR,"Error","Invalid username or password"));
			navaigateTo = "";
			
		}
		return navaigateTo;

	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	

	public boolean isLoggedInAsAdmin() {
		return loggedInAsAdmin;
	}

	public void setLoggedInAsAdmin(boolean loggedInAsAdmin) {
		this.loggedInAsAdmin = loggedInAsAdmin;
	}

	public boolean isLoggedInAsUser() {
		return loggedInAsUser;
	}

	public void setLoggedInAsUser(boolean loggedInAsUser) {
		this.loggedInAsUser = loggedInAsUser;
	}

	public Boolean getIdentifidUser() {
		return identifidUser;
	}

	public void setIdentifidUser(Boolean identifidUser) {
		this.identifidUser = identifidUser;
	}

}