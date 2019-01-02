package bean;

import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import org.primefaces.model.chart.Axis;
import org.primefaces.model.chart.AxisType;
import org.primefaces.model.chart.BarChartModel;
import org.primefaces.model.chart.CategoryAxis;
import org.primefaces.model.chart.ChartSeries;
import org.primefaces.model.chart.LineChartModel;

import Entities.Project;
import Entities.User;
import Interfaces.ProjectServiceLocal;

@SessionScoped
@ManagedBean
public class ProjectDoneBean {
private BarChartModel lineModel2;
@EJB
public ProjectServiceLocal p ;
public List<Project> ps;
public Project pe;
	public ProjectDoneBean() {
		// TODO Auto-generated constructor stub
	}
 public long Rentable(Project pe){
	 long x=0;
	 long somme=0;
	
	 for (User ua : pe.getUsers()){
		 
		   somme=(long) (ua.getSalary()*calculerJour(pe.getEndDate(), pe.getStartDate())+somme);
	   }
	 x=pe.getValue()-somme;
	
	 return x;
 }
 public long calculerJour(Date t1,Date t2){
		return(t1.getTime()-t2.getTime())/ 86400000;
	}
public List<Project> getPs() {
	return p.getPdone();
}
public void setPs(List<Project> ps) {
	this.ps = ps;
}
public Project getPe() {
	return pe;
}
public void setPe(Project pe) {
	this.pe = pe;
}

private BarChartModel  initCategoryModel(){
	BarChartModel model = new BarChartModel();

	ChartSeries boys = new ChartSeries();
	for(Project pii : p.getPdone()){ 
	long x=0;
	 long somme=0;
	
	 for (User ua : pii.getUsers()){
		 
		   somme=(long) (ua.getSalary()*calculerJour(pii.getEndDate(), pii.getStartDate())+somme);
	   }
	 x=pii.getValue()-somme;
	
	boys.set(pii.getName(),x);
	boys.setLabel("MostProjectProfabilite");
	
}
	model.addSeries(boys);
	return model;
}
@PostConstruct
public void init (){
	create();
}
public void create(){
	lineModel2 = initCategoryModel();
	 
	lineModel2.setTitle("Bar Chart");
	lineModel2.setLegendPosition("ne");

    Axis xAxis = lineModel2.getAxis(AxisType.X);
    xAxis.setLabel("Gender");

    Axis yAxis = lineModel2.getAxis(AxisType.Y);
    yAxis.setLabel("Births");
    yAxis.setMin(0);
    yAxis.setMax(100000);
}
public BarChartModel getLineModel2() {
	return lineModel2;
}
public void setLineModel2(BarChartModel lineModel2) {
	this.lineModel2 = lineModel2;
}

}
