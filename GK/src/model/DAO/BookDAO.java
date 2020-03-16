package model.DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

import model.bean.Book;

public class BookDAO {
	private static String url = "jdbc:sqlserver://localhost:1433; databaseName=DATA480;";
	private static String username = "sa";
	private static String password = "123456";

	Connection connection;

	public void connect() {
		try {
			Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
			connection = DriverManager.getConnection(url, username, password);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public ArrayList<Book> getlistBooks(String id) {
		connect();
		String sql = String.format("SELECT * FROM Books Where ID= '%s'", id);
		ResultSet rs = null;
		try {
			Statement stm = connection.createStatement();
			rs = stm.executeQuery(sql);
		} catch (SQLException e) {
			e.printStackTrace();
		}

		ArrayList<Book> list = new ArrayList<>();
		Book book;

		try {
			while (rs.next()) {
				book = new Book();
				book.setTenSach(rs.getString("TenSach"));
				book.setNhaXB(rs.getString("NhaXB"));
				book.setSoLuong(rs.getInt("SoLuong"));
				book.setNamXB(rs.getInt("NamXB"));
				list.add(book);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return list;
	}

}
