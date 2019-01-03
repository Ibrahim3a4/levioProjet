package bean;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ApplicationScoped;
import javax.faces.bean.ManagedBean;

import Entities.Parrain;
import Entities.User;
import Service.ParrainService;

@ManagedBean(name="themeService", eager = true)
@ApplicationScoped
public class ParrainS {
	
	@EJB
	ParrainService ps ; 
	List<Parrain> pp;
	@PostConstruct
	public void init (){
		pp= new ArrayList<>();
		pp=ps.getAll();
	}
	public List<Parrain> getPp() {
		return pp;
	}
	public void setPp(List<Parrain> pp) {
		this.pp = pp;
	}
	

}
