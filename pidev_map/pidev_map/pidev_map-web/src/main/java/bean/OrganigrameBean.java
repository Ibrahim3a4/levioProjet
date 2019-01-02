package bean;

import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import Entities.Project;
import Entities.User;
import Interfaces.UserServiceLocal;
@ManagedBean
@SessionScoped
public class OrganigrameBean {
@EJB 
UserServiceLocal us ; 
	public List<User> users ;
	public List<Project> projects ;
	public List<User> users2;
	 private String style = "width: 800px";

	public String getStyle() {
		return style;
	}
	public void setStyle(String style) {
		this.style = style;
	}
	@PostConstruct
	public void init() {
		users = us.getClients();
		
		System.err.println(users);
	}
	public OrganigrameBean() {
		
	}
	public List<User> getUsers() {
		return users;
	}
	public void setUsers(List<User> users) {
		this.users = users;
	}
	public List<Project> getProjects() {
		return projects;
	}
	public void setProjects(List<Project> projects) {
		this.projects = projects;
	}
	public List<User> getUsers2() {
		return users2;
	}
	public void setUsers2(List<User> users2) {
		this.users2 = users2;
	}

}
