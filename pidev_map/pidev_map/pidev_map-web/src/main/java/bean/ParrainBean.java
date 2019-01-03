package bean;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.persistence.Query;

import Entities.Parrain;
import Entities.User;
import Interfaces.UserServiceLocal;
import Service.ParrainService;
import Service.ParrainServiceLocal;
import Service.UserService;

import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;

@ManagedBean
@SessionScoped
public class ParrainBean {
	
	@EJB
	private ParrainServiceLocal service;
	@EJB 
	private UserServiceLocal ssss;
	public List<User> uss;
	public List<Parrain> pss;
	private int idParrain;
	private String idUser;
	Parrain po = new Parrain();
	
	public Parrain getPo() {
		return po;
	}
	public void setPo(Parrain po) {
		this.po = po;
	}
	public List<User> getUss() {
		return ssss.getAll();
	}
	public void setUss(List<User> uss) {
		this.uss = uss;
	}
	public List<Parrain> getPss() {
		return service.getAll();
	}
	public void setPss(List<Parrain> pss) {
		this.pss = pss;
	}

	private int selectedParrain;
	private String selectedUser;
	
	public int getSelectedParrain() {
		return selectedParrain;
	}
	public void setSelectedParrain(int selectedParrain) {
		this.selectedParrain = selectedParrain;
	}
	public String getSelectedUser() {
		return selectedUser;
	}
	public void setSelectedUser(String selectedUser) {
		this.selectedUser = selectedUser;
	}

	private Parrain parrain= new Parrain();
	
	private User ua = new User();
	@EJB 
	UserService serviceUser;
	
	
	 
    @EJB
    ParrainService serviceParrain;
    
	
	
	
	public List<Parrain> p;
	

	public int getIdParrain() {
		return idParrain;
	}
	public void setIdParrain(int idParrain) {
		this.idParrain = idParrain;
	}
	public String getIdUser() {
		return idUser;
	}
	public void setIdUser(String idUser) {
		this.idUser = idUser;
	}

	public Parrain getParrain() {
		return parrain;
	}
	public void setParrain(Parrain parrain) {
		this.parrain = parrain;
	}
	public User getUa() {
		return ua;
	}
	public void setUa(User ua) {
		this.ua = ua;
	}
	
	
	public List<Parrain> getP() {
		return p;
	}
	public void setP(List<Parrain> p) {
		this.p = p;
	}
	public String addParrain(){
		service.addParrain(parrain);
		return "/ListParrain.xhtml?faces-redirect=true";
	}
	public List<Parrain> getParrains(){
		return p;
	}
	
	


	/*
	public void assignParrainUser(){
		serviceParrain.assignParrainUser(idUser,idParrain);
		
	}*/
	public List<User> afficherUser(){
		return serviceParrain.afficherUser();
	
	}
	public List<Parrain> afficherParrain(){
		return serviceParrain.getAll();
		
	}
	public void affecterUserParrain(){
		serviceParrain.affecterUserParrain(selectedUser, selectedParrain);
		
	}
	/*public int removeReview (int ReviewId)
	    {
	    	ReviewManagementLocal.deleteReviewbyid(ReviewId);
	    	System.out.println("supprimee2");
	    	return ReviewId;
	    }*/
	

	
	
	public ParrainServiceLocal getService() {
		return service;
	}
	public void setService(ParrainServiceLocal service) {
		this.service = service;
	}
	public UserServiceLocal getSsss() {
		return ssss;
	}
	public void setSsss(UserServiceLocal ssss) {
		this.ssss = ssss;
	}
	public UserService getServiceUser() {
		return serviceUser;
	}
	public void setServiceUser(UserService serviceUser) {
		this.serviceUser = serviceUser;
	}
	public ParrainService getServiceParrain() {
		return serviceParrain;
	}
	public void setServiceParrain(ParrainService serviceParrain) {
		this.serviceParrain = serviceParrain;
	}
	
	public Parrain BestParrain(){
		return serviceParrain.BestParrain();
		
	}
	public String go(){
		return "/ListParrain?faces-redirect=true";
	}
	
	}
