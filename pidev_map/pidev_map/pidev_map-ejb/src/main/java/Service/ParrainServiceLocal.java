package Service;

import java.util.List;

import javax.ejb.Local;

import Entities.Parrain;
import Entities.User;

@Local
public interface ParrainServiceLocal {
	 public void addParrain(Parrain p);
	
	  public void UpdateParrain(Parrain p);
	  public Parrain BestParrain();
	 public List<Parrain> getAll();
	// public void addUti(User u);
	 public List<User> afficherUser();
	 public List<Parrain> afficherParrain();
	 public void affecterUserParrain(String idUser, int idParrain);
}
