package controller;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import model.BO.BookBO;
import model.bean.Book;
import model.bean.User;

/**
 * Servlet implementation class ViewResultServlet
 */
@WebServlet("/ViewResultServlet")
public class ViewResultServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public ViewResultServlet() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		response.setCharacterEncoding("utf-8");
		response.setContentType("text/html");

		PrintWriter out = response.getWriter();

		HttpSession ss = request.getSession();
		User acc = (User) ss.getAttribute("user");
		if (acc == null) {
			out.print("<font color='red'><i>Bạn chưa đăng nhập </i></font>");
			RequestDispatcher rds = request.getRequestDispatcher("Login.jsp");
			rds.include(request, response);
		} else {
			BookBO bookbo = new BookBO();

			String id = acc.getId();
			ArrayList<Book> list = bookbo.getlistBooks(id);
			request.setAttribute("getlist", list);

			RequestDispatcher rdr = request.getRequestDispatcher("ViewResult.jsp");
			rdr.forward(request, response);
		}

	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
