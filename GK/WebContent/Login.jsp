<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<form action="LoginServlet">
		<table align="left">
			<tr>
				<td>Tên đăng nhập</td>
				<td><input type="text" name="username" value="admin"></td>
			</tr>
			<tr>
				<td>Mật khẩu</td>
				<td><input type="password" name="password" value="123"></td>
			</tr>
			<tr>
				<td><input type="submit" value="Đăng nhập"></td>
			</tr>
		</table>
	</form>
</body>
</html>