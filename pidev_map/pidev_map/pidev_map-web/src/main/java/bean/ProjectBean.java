package bean;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ApplicationScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.bean.ViewScoped;

import Entities.Project;
import Interfaces.ProjectServiceLocal;
import Interfaces.ProjectServiceRemote;



@ManagedBean
@ViewScoped
public class ProjectBean {

	@EJB
	ProjectServiceRemote service;
	
	private List<Project> ps ;


	public void setPs(List<Project> ps) {
		this.ps = ps;
	}
	public List<Project> getPs() {
	
		
		return ps;
		}
	public void init(){
		
		ps= service.getAll2();
		System.out.println(ps);
	}
	

	
	
}
