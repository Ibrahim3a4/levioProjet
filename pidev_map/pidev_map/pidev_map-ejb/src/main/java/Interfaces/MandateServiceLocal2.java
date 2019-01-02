package Interfaces;

import java.util.List;

import javax.ejb.Local;

import Entities.Mandate;
@Local
public interface MandateServiceLocal2 {
	public List<Mandate> GetById(int id);
	public void addMandate(Mandate m);
	List<Mandate> getall();
}
