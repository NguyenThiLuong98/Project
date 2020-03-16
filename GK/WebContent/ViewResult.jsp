<%@page import="model.bean.Book"%>
<%@page import="java.util.ArrayList"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
	<table border="1" cellpadding="15" cellspacing="0">
		<tr>
			<th>Tên sách</th>
			<th>Nhà xb</th>
			<th>Số lượng</th>
			<th>Năm xb</th>

		</tr>
		<%
			ArrayList<Book> list = (ArrayList<Book>) request.getAttribute("getlist");
			for (Book book : list) {
		%>

		<tr>
			<td><%=book.getTenSach()%></td>
			<td><%=book.getNhaXB()%></td>
			<td><%=book.getSoLuong()%></td>
			<td><%=book.getNamXB()%></td>

		</tr>
		<%
			}
		%>
	</table>

</body>
</html>