package bean;

import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

import Entities.User;
import Interfaces.UserServiceLocal;


@ManagedBean
@SessionScoped
public class EditUser {
	private User u;
	@EJB
		private UserServiceLocal service;
	public User getU() {
		return u;
	}

	public void setU(User u) {
		this.u = u;
	}
	
	public String load(){
		return "edit.xhtml";
	}
	
	public String Update()
	{
		service.UpdateUser(u);
		
		/*
		ExternalContext ec= FacesContext.getCurrentInstance().getExternalContext();
		try {
			ec.redirect("");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}*/
		return"/User/profile?faces-redirect=true";
	}
	public String UpdateAdmin()
	{
		service.UpdateUser(u);
		
		/*
		ExternalContext ec= FacesContext.getCurrentInstance().getExternalContext();
		try {
			ec.redirect("");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}*/
		return"/Admin/listUsers?faces-redirect=true";
	}
	public String Delete(User us){
		try{
		service.DeleteUser(us);
		FacesContext fc= FacesContext.getCurrentInstance();
		fc.addMessage(null,new FacesMessage(FacesMessage.SEVERITY_INFO,"Succès","Utilisateur supprimé"));
		}
		catch (Exception e){
			FacesContext fc= FacesContext.getCurrentInstance();
			fc.addMessage(null,new FacesMessage(FacesMessage.SEVERITY_ERROR,"Erreur","Erreur lors de la suppression"));
		}
		return "";
	}

}
