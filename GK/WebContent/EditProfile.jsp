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
	<%
		User nguoidung = (User) session.getAttribute("user");
		if (nguoidung == null) {
	%>
	<font color="red"><i>Bạn chưa đăng nhập</i></font>
	<%@include file="Login.jsp"%>
	<%
		} else {
	%>
	Thông tin tài khoản đăng nhập:
	<br> -Tên đăng nhập:
	<%=nguoidung.getUsername()%>
	<br> -Tên cũ:
	<%=nguoidung.getFullname()%>
	<form action="EditProfileServlet">
		-Tên mới: <input type="text" name="fullname"> <input
			type="submit" value="Sửa">
	</form>
	<%
		}
	%>

</body>
</html>