package Service;

import java.util.List;

import javax.ejb.Remote;

import Entities.Parrain;
import Entities.User;

@Remote
public interface ParrainServiceRemote {
	 public void addParrain(Parrain p);

	  public void UpdateParrain(Parrain p);
	  public Parrain BestParrain();
	 public List<Parrain> getAll();
//	 public void addUti(User u);
	 public void affecterUserParrain(String idUser, int idParrain);
	 public List<User> afficherUser();
	 public List<Parrain> afficherParrain();
}
