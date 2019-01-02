package Interfaces;

import java.util.List;

import javax.ejb.Local;

import Entities.Mandate;
import Entities.Project;

@Local
public interface ProjectServiceLocal {
	public List<Project> getAll2();
	public  List<Project> getAll();
	Project getbyid(int id);
	public  List<Project> getPdone();
}
