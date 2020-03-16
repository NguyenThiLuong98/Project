package model.DAO;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import model.bean.User;

public class UserDAO {
	public User account = new User();
	private static String url = "jdbc:sqlserver://localhost:1433;databaseName=DATA480;";
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
			// TODO: handle exception
			e.printStackTrace();
		}
	}

	public boolean checkLogin(String username, String password) {
		connect();
		String sql = String.format("SELECT ID,Fullname FROM Users WHERE Username= '%s' AND Password= '%s'", username,
				password);

		ResultSet rs = null;
		try {
			Statement sttm = connection.createStatement();
			rs = sttm.executeQuery(sql);
		} catch (SQLException e) {
			// TODO: handle exception
			e.printStackTrace();
		}

		try {
			if (rs.next()) {
				account.setId(rs.getString("id"));
				account.setUsername(username);
				account.setPassword(password);
				account.setFullname(rs.getString("fullname"));
				return true;
			}
		} catch (SQLException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return false;
	}

	public boolean updateProfile(String id, String fullName) {
		connect();
		String sql = String.format("UPDATE Users SET Fullname = '%s' WHERE ID = '%s' ", fullName, id);
		try {
			Statement sttm = connection.createStatement();
			int result = sttm.executeUpdate(sql);
			if (result > 0)
				return true;
		} catch (SQLException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return false;
	}

}
