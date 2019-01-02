package bean;
 
import javax.annotation.PostConstruct;
import javax.ejb.EJB;

import java.io.Serializable;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import org.primefaces.component.chart.Chart;
import org.primefaces.model.chart.BarChartModel;
import org.primefaces.model.chart.ChartSeries;
import org.primefaces.model.chart.LineChartModel;
import org.primefaces.model.chart.PieChartModel;


import Interfaces.UserServiceLocal;  
@ManagedBean 
@SessionScoped
public class PieChart  {  
private PieChartModel pieModel;
public Map<String, Long> m;
private BarChartModel barModel;

@EJB
UserServiceLocal service;
public Map<String, Long> getM() {
	return m;
}

public void setM(Map<String, Long> m) {
	this.m = m;
}


@PostConstruct  
public void init() {  
  

createPieModels();
}  
public PieChartModel getPieModel() {  
return pieModel;  
}  
private void createPieModels() {  
createPieModel();  
}  
private void createPieModel() {  
pieModel = new PieChartModel();  

m = service.getUsersByTown();
Set<Entry<String, Long>> set = m.entrySet();

Iterator<Entry<String, Long>> it = set.iterator();
while (it.hasNext()){
	
	Entry<String, Long> e = it.next();
	pieModel.set(e.getKey(),e.getValue());
	
	}
pieModel.setTitle("Car Brands");  
pieModel.setLegendPosition("c");

}

}  