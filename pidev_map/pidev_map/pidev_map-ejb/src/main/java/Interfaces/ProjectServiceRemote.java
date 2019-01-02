package Interfaces;

import java.util.List;

import javax.ejb.Remote;

import Entities.Mandate;
import Entities.Project;

@Remote
public interface ProjectServiceRemote {
	public List<Project> getAll2();
	public  List<Project> getAll();
	Project getbyid(int id);
	public  List<Project> getPdone();
}
