<%@ Page Language="c#" AutoEventWireup="false" CodeFile="APIError.aspx.cs" Inherits="APIError" %>
<HTML>
	<HEAD runat="server">
		<title>SkiChair.com - Error Page</title>
	</HEAD>
	<body>
		
		<TABLE class="api" id="Table1">
			<TR>
				<TD class="field"></TD>
				<TD>We are sorry but there was a problem with your payment. Please call The Chairman at (508) 335-2202</TD>
			</TR>
			<TR>
				<TD class="field"></TD>
				<TD>Error Code: <%=Request.QueryString.Get("ErrorCode")%></TD>
			</TR>
			
			<TR>
				<TD class="field"></TD>
				<TD>Error Description: <%=Request.QueryString.Get("Desc")%></TD>
			</TR>
			
			<TR>
				<TD class="field"></TD>
				<TD>Additional Error Description: <%=Request.QueryString.Get("Desc2")%></TD>
			</TR>

		</TABLE>
	</body>
</HTML>
