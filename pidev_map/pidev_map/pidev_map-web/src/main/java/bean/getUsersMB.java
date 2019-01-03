package bean;

import java.util.List;

import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

import Entities.Parrain;
import Entities.User;
import Interfaces.UserServiceLocal;
import Service.ParrainServiceLocal;



@ManagedBean
@ViewScoped
public class getUsersMB {
	
	@EJB
	UserServiceLocal service;
    @EJB
    ParrainServiceLocal se;
	public List<User> users;
    public List<Parrain> ps ; 
	public List<Parrain> getPs() {
		return ps;
	}

	public void setPs(List<Parrain> ps) {
		this.ps = ps;
	}

	public List<User> getUsers() {
		return users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}
	
	public void init(){
		users= service.getAll();
		ps=se.getAll();
	}
	
	
	
}
