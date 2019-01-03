package Interfaces;

import java.util.List;
import java.util.Map;

import javax.ejb.Local;

import Entities.User;
@Local
public interface UserServiceLocal {
	public Map<String,Long> getUsersByTown();
	void AddUser (User user);
	void DeleteUser(User user);
	User getUserById(String id);
	void UpdateUser(User user);
	User findUserByLogin(String login, String password);
    
	public List<User> getMostActiveUsers();
	public List<User> getAll();
	public void deleteUserInter(String id);
	 public List<User>getAllInter();
}
