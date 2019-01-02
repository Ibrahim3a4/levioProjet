package bean;

import java.util.Map;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
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
public class AddUserMB {
	@EJB
	private UserServiceLocal service;
	
	private User user = new User() ; 
	private String pass;
	
	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
	
	
	public String getPass() {
		return pass;
	}

	public void setPass(String pass) {
		this.pass = pass;
	}

	public void doadd() {
		service.AddUser(user);
	}

	
	
	public String getParam (String id)
	{
		FacesContext fc=FacesContext.getCurrentInstance();
		Map<String,String> params =fc.getExternalContext().getRequestParameterMap();
		return params.get(id);
		
		
	}
	

	

	public String Register(User user) {

		Client client = ClientBuilder.newClient();
		WebTarget target = client.target("http://localhost:54331/api/Register");

		Response reponse = target.request().post(Entity.entity(user, MediaType.APPLICATION_JSON));
		String result = reponse.readEntity(String.class);
		System.out.println(result);
		reponse.close();
		return result;
	}

	
	
}
