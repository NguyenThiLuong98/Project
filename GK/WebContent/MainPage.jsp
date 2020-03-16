<%@page import="model.bean.User"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	Hello,
	<%
	User nguoiDung = (User) session.getAttribute("user");
	if (nguoiDung == null) {
		out.print("Welcome my WebSite!");
	} else {
		out.print(nguoiDung.getFullname() + "!");
%>
	<a href="EditProfile.jsp">Sửa Thông Tin Đăng Nhập</a>
	<a href="ViewResultServlet">Xem Thông Tin</a>
	<a href="LogOut.jsp">Đăng Xuất</a>
	<%
		}
	%>
</body>
</html>