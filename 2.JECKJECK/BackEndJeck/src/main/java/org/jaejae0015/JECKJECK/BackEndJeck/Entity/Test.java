package org.jaejae0015.JECKJECK.BackEndJeck.Entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;

@Getter
@Entity
@Table(name="test_tb")
public class Test {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int UIDX;
	
	@Column(length=100,nullable=false)
	private String USERID;

}
