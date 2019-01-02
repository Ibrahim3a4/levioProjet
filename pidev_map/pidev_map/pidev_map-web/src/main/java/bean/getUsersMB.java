package bean;

import java.util.List;

import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

import Entities.User;
import Interfaces.UserServiceLocal;



@ManagedBean
@ViewScoped
public class getUsersMB {
	
	@EJB
	UserServiceLocal service;
	public List<User> users;
	public List<User> users2;

	public List<User> getUsers() {
		return users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}
	
	public void init(){
		users= service.getClients();
		users2=service.getRessources();
	}

	public List<User> getUsers2() {
		return users2;
	}

	public void setUsers2(List<User> users2) {
		this.users2 = users2;
	}
	
	
}
