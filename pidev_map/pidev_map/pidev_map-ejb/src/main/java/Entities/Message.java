package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.sql.Timestamp;


/**
 * The persistent class for the Messages database table.
 * 
 */
@Entity
@Table(name="Messages")
@NamedQuery(name="Message.findAll", query="SELECT m FROM Message m")
public class Message implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="MessageId")
	private int messageId;

	@Column(name="Content")
	private  String content;

	@Column(name="MessageDate")
	private Timestamp messageDate;

	@Column(name="Received")
	private boolean received;

	@Column(name="Receiver")
	private  String receiver;

	@Column(name="Sender")
	private  String sender;

	@Column(name="Subject")
	private  String subject;

	@Column(name="Type")
	private int type;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="MUser_Id")
	private User user;

	public Message() {
	}

	public int getMessageId() {
		return this.messageId;
	}

	public void setMessageId(int messageId) {
		this.messageId = messageId;
	}

	public Object getContent() {
		return this.content;
	}

	public void setContent( String content) {
		this.content = content;
	}

	public Timestamp getMessageDate() {
		return this.messageDate;
	}

	public void setMessageDate(Timestamp messageDate) {
		this.messageDate = messageDate;
	}

	public boolean getReceived() {
		return this.received;
	}

	public void setReceived(boolean received) {
		this.received = received;
	}

	public  String getReceiver() {
		return this.receiver;
	}

	public void setReceiver( String receiver) {
		this.receiver = receiver;
	}

	public  String getSender() {
		return this.sender;
	}

	public void setSender( String sender) {
		this.sender = sender;
	}

	public Object getSubject() {
		return this.subject;
	}

	public void setSubject( String subject) {
		this.subject = subject;
	}

	public int getType() {
		return this.type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

}