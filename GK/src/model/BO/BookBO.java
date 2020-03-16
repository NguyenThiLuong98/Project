package model.BO;

import java.util.ArrayList;

import model.DAO.BookDAO;
import model.bean.Book;

public class BookBO {
	BookDAO bookDAO= new BookDAO();
	
	public ArrayList<Book> getlistBooks(String id){
		 return bookDAO.getlistBooks(id);
	}

}
