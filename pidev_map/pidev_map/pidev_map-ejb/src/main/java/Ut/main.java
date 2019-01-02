package Ut;


import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.GenericType;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.json.JSONArray;
import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import Entities.Project;
import Entities.User;
import Interfaces.ProjectServiceLocal;
import Service.ProjectService;


public class main {

	public static void main(String[] args) {
   List<Project> ps = new ArrayList<Project>();
   ProjectServiceLocal  p = new ProjectService();
   String schema ="http://localhost:54331/Api/add/f72bc2ad-7df6-4cf9-adbc-6bc25d477c6f";
	try{
		Document data = Jsoup.connect(schema).ignoreContentType(true).get();
		String json = data.select("body").text();
		Gson g = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
		
		
	}
	catch (Exception E){
		E.printStackTrace();
	}
	ps = p.getAll();
	System.out.println(ps);
}
}