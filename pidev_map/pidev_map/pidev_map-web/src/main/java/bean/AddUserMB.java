package bean;

import java.util.List;
import java.util.Map;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.persistence.Query;

import Entities.Parrain;
import Entities.User;
import Interfaces.UserServiceLocal;
import Service.ParrainServiceLocal;


@ManagedBean
@SessionScoped
public class AddUserMB {
	@EJB
	private UserServiceLocal service;
	private User user = new User() ; 
	
    @EJB
    ParrainServiceLocal se;
	public List<User> users;
    public List<Parrain> ps ;
	

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
  public List<User> displayAllUsersInter(){
	  users=service.getAllInter();
	  return users;
  }
	
	public UserServiceLocal getService() {
		return service;
	}

	public void setService(UserServiceLocal service) {
		this.service = service;
	}

	public ParrainServiceLocal getSe() {
		return se;
	}

	public void setSe(ParrainServiceLocal se) {
		this.se = se;
	}

	public List<User> getUsers() {
		return users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

	public List<Parrain> getPs() {
		return ps;
	}

	public void setPs(List<Parrain> ps) {
		this.ps = ps;
	}

	public String doadd() {
		
		service.AddUser(user); 
		return "login.xhtml?faces-redirect=true";
	}

	
	
	public String getParam (String id)
	{
		FacesContext fc=FacesContext.getCurrentInstance();
		Map<String,String> params =fc.getExternalContext().getRequestParameterMap();
		return params.get(id);
		
		
	}
	
	
	public String removeUserInter(User u){
		service.deleteUserInter(u.getId());
		return "";
	}
	

}
