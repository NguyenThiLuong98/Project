package model.BO;

import model.DAO.UserDAO;
import model.bean.User;

public class UserBO {
	UserDAO userDAO = new UserDAO();

	public boolean checkLogin(String username, String password) {
		return userDAO.checkLogin(username, password);
	}

	public User userInfo() {
		return userDAO.account;
	}

	public boolean updateProfile(String id, String fullName) {
		return userDAO.updateProfile(id, fullName);
	}

}
