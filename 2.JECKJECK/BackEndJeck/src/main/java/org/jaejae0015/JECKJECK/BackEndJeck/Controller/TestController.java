package org.jaejae0015.JECKJECK.BackEndJeck.Controller;

import java.util.ArrayList;
import java.util.List;

import org.jaejae0015.JECKJECK.BackEndJeck.Entity.Test;
import org.jaejae0015.JECKJECK.BackEndJeck.Repository.TestRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TestController {
	
	@Autowired
	TestRepository testRepository;
	
	@GetMapping("/api/test")
	public List<Test> getTest() {
		//List<> items = new ArrayList<>();
		//List<String> items = new ArrayList<>();
		//items.add("alpha");
		//items.add("beta");
		//items.add("gamma");
		//return items;
		
		//JPA
		List<Test> items = testRepository.findAll();
		
		return items;
		
	}

}
